    public class FormatterFactory
    {
      Dictionary<string, IFormatter> _formatters;
    
      public void FormatterFactory()
      {
          var baseType = typeof(IFormatter);
          var formatterTypes = AppDomain
                .GetExecutingAssembly()
                .GetTypes.Where(x=>baseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
    
           // convention based. Each formatter must be named like "JsonFormatter"
           foreach (var type in formatterTypes) 
           {
               _formatters.Add(type.Name.Replace("Formatter", "").ToLower(), type), 
           }
      }
      public IFormatter Create(string formatName)
      {
          var type = _formatters[formatName.ToLower());
          return (IFormatter)Activator.CreateInstance(type);
          
      }
    }
