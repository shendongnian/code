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
