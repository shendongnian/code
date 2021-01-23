    internal class DataType<T>
    {
          public string Name {get;set}
          public T Value {get;set;}
          public Type Type
          {
              get { return typeof(T); }
          }
    
          public string VariableDefinition()
          {
              /* Construct string */
          }
    }
