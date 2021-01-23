    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class OptionalTheoryAttribute : TheoryAttribute
    {
        protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
        {
            var result = (List<ITestCommand>)base.EnumerateTestCommands(method);
            try
            {
                return TransferToSupportOptional(result, method);
            }
            catch (Exception ex)
            {
                result.Clear();
                result.Add(new LambdaTestCommand(method, () =>
                    {
                        throw new InvalidOperationException(
                            String.Format("An exception was thrown while getting data for theory {0}.{1}:\r\n{2}",
                                method.TypeName, method.Name, ex)
                            );
                    }));
            }
            return result;
        }
        private static IEnumerable<ITestCommand> TransferToSupportOptional(
            IEnumerable<ITestCommand> testCommands, IMethodInfo method)
        {
            var parameterInfos = method.MethodInfo.GetParameters();
            foreach (var testCommand in testCommands.OfType<TheoryCommand>())
            {
                typeof(TheoryCommand)
                    .GetProperty("Parameters")
                    .SetValue(testCommand, GetParameterValues(testCommand, parameterInfos));
                yield return testCommand;
            }
        }
        private static object[] GetParameterValues(TheoryCommand testCommand, ParameterInfo[] parameterInfos)
        {
            var specifiedValues = testCommand.Parameters;
            var optionalValues = GetOptionalValues(testCommand, parameterInfos);
            return specifiedValues.Concat(optionalValues).ToArray();
        }
        private static IEnumerable<object> GetOptionalValues(TheoryCommand command, ParameterInfo[] parameterInfos)
        {
            return Enumerable.Range(command.Parameters.Length, parameterInfos.Length - command.Parameters.Length)
                             .ToList().Select(i =>
                                 {
                                     EnsureIsOptional(parameterInfos[i]);
                                     return Type.Missing;
                                 });
        }
        private static void EnsureIsOptional(ParameterInfo parameterInfo)
        {
            if (!parameterInfo.IsOptional)
            {
                throw new ArgumentException(string.Format(
                    "The parameter '{0}' should be optional or specified from data attribute.",
                    parameterInfo));
            }
        }
    }
    internal class LambdaTestCommand : TestCommand
    {
        private readonly Assert.ThrowsDelegate lambda;
        public LambdaTestCommand(IMethodInfo method, Assert.ThrowsDelegate lambda)
            : base(method, null, 0)
        {
            this.lambda = lambda;
        }
        public override bool ShouldCreateInstance
        {
            get
            {
                return false;
            }
        }
        public override MethodResult Execute(object testClass)
        {
            try
            {
                lambda();
                return new PassedResult(testMethod, DisplayName);
            }
            catch (Exception ex)
            {
                return new FailedResult(testMethod, ex, DisplayName);
            }
        }
    }
    public class OptionalTheoryTest
    {
        [OptionalTheory]
        [InlineData(1)]
        [InlineData(1, true)]
        public void TestMethod(int num, bool fast = true)
        {
            // Arrange
            // Act
            // Assert
            Assert.Equal(1, num);
            Assert.True(fast);
        }
    }
