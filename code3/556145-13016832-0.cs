    public enum ParameterType
    {
        Empty = 0,
        Boolean = 1,
        Integer = 2,
        String = 3,
        DateTime = 4,
        ...
    }
    class JobParameter
    { 
      [AValidationAttributeForAllParamters] 
      public string Name { get; set; }  
      public virtual string Foo { get; set; }  
      public int Number { get; set; }
      public ParameterType Type {get;set;}
    
      private static readonly IDictionary<ParameterType, Func<object>> ParameterTypeDictionary =
      new Dictionary<ParameterType, Func<object>>{
                    {ParameterType.Empty, () => new EmptyParameter() },
                    {ParameterType.String, ()=>new StringParameter()},
                    {ParameterType.Password, ()=>new PasswordParameter()},
                    ...
                  };
        public static ScriptParameter Factory(ParameterType type)
        {
            return (ScriptParameter)ParameterTypeDictionary[type]();
        }
    }  
    [ABoolClassLevelValidationAttribute]
    class BoolParameter:JobParameter
    {
        [AValidationAttribute]
        public override string Foo {get;set;}
    }
    ....
