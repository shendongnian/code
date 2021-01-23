    public class CaseBuilder
    {
        /// <summary>
        /// The options of this case.
        /// </summary>
        public List<CaseBuilderOption> Options { get; set; }
        /// <summary>
        /// Else return value.
        /// </summary>
        public object ElseValue { get; set; }
        /// <summary>
        /// Type of return value.
        /// </summary>
        public Type ReturnType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="case1"></param>
        /// <param name="value1"></param>
        /// <param name="elseValue"></param>
        public CaseBuilder(Type returnType, object when, object then, object elseValue)
        {
            ReturnType = returnType;
            if (then.GetType() != returnType || elseValue.GetType() != returnType)
            {
                throw new Exception();
            }
            Options = new List<CaseBuilderOption>();
            Options.Add(new CaseBuilderOption() { When = when, Then = then });
            ElseValue = elseValue;
        }
        /// <summary>
        /// Add a WhenThen option to the case builder.
        /// </summary>
        /// <param name="when"></param>
        /// <param name="then"></param>
        /// <returns></returns>
        public CaseBuilder Append(object when, object then)
        {
            if (then.GetType() != ReturnType)
            {
                throw new Exception();
            }
            Options.Add(new CaseBuilderOption() { When = when, Then = then });
            return this;
        }
    }
    /// <summary>
    /// A When Then option of a Case
    /// </summary>
    public class CaseBuilderOption
    {
        /// <summary>
        /// When
        /// </summary>
        public object When { get; set; }
        /// <summary>
        /// returns this value if When and Case property are equal
        /// </summary>
        public object Then { get; set; }
    }
