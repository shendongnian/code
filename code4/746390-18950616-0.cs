    /// <summary>
    /// This is a base class for all the specs. Note this spec is NOT thread safe. (But then
    /// I don't see MSpec running parallel tests anyway)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// This class provides setup of a fixture which contains a) access to class under test
    /// b) an auto mocking container and c) enforce a clean fixture for every spec.
    /// </remarks>
    public abstract class BaseSpec<T>
        where T : class
    {
        public static TestFixture Fixture;
        private Establish a_new_context = () =>
            {
                Fixture = new TestFixture();
                MockedTypes = new Dictionary<Type, Action>();
            };
        /// <summary>
        /// This dictionary holds a list of mocks that need to be verified by the behavior.
        /// </summary>
        private static Dictionary<Type, Action> MockedTypes;
        /// <summary>
        /// Gets the mock of a requested type, and it creates a verify method that is used
        /// in the "AllMocksVerified" behavior.
        /// </summary>
        /// <typeparam name="TMock"></typeparam>
        /// <returns></returns>
        public static Mock<TMock> GetMock<TMock>()
            where TMock : class
        {
            var mock = Mock.Get(Fixture.Context.Get<TMock>());
            if (!MockedTypes.ContainsKey(typeof(TMock)))
                MockedTypes.Add(typeof(TMock), mock.VerifyAll);
            return mock;
        }
  
        [Behaviors]
        public class AllMocksVerified
        {
            private Machine.Specifications.It should_verify_all =
            () =>
            {
                foreach (var mockedType in MockedTypes)
                {
                    mockedType.Value();
                }
            };
        }
        public class TestFixture
        {
            public MoqAutoMocker<T> Context { get; private set; }
            public T TestTarget
            {
                get { return Context.ClassUnderTest; }
            }
            public TestFixture()
            {
                Context = new MoqAutoMocker<T>();
            }
        }
    }
