    class CustomIdentifier {
       
       public const string Pattern = @"(.+?)-(.+)";
       static readonly Regex Regex = new Regex(Pattern);
       public string Keyword { get; private set; }
       public string Value { get; private set; }
    
       public static CustomIdentifier Parse(string identifier) {
          
          if (identifier == null) throw new ArgumentNullException("identifier");
          Match match = Regex.Match(identifier);
          if (!match.Success)
             throw new ArgumentException("identifier is invalid.", "identifier");
          return new CustomIdentifier {
             Keyword = match.Groups[1].Value,
             Value = match.Groups[2].Value
          };
       }
    }
    
    class CustomIdentifierModelBinder : IModelBinder {
       public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
          return CustomIdentifier.Parse(
             (string)bindingContext.ValueProvider.GetValue(bindingContext.ModelName).RawValue
          );
       }
    }
