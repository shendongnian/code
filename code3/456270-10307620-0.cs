    [AttributeUsage(AttributeTargets.Field)]
    sealed class TemplateAttribute : Attribute {
    
      public TemplateAttribute(String fileName) {
        FileName = fileName;
      }
    
      public String FileName { get; set; }
    
    }
    
    enum EmailTemplates {
      [Template("File1.htm")]
      WelcomeEmail,
      [Template("File2.htm")]
      ConfirmEmail
    }
    
    class KnownTemplates {
    
      static Dictionary<EmailTemplates, String> knownTemplates;
    
      static KnownTemplates() {
        knownTemplates = typeof(EmailTemplates)
          .GetFields(BindingFlags.Static | BindingFlags.Public)
          .Where(fieldInfo => Attribute.IsDefined(fieldInfo, typeof(TemplateAttribute)))
          .Select(
            fieldInfo => new {
              Value = (EmailTemplates) fieldInfo.GetValue(null),
              Template = (TemplateAttribute) Attribute
                .GetCustomAttribute(fieldInfo, typeof(TemplateAttribute))
            }
          )
          .ToDictionary(x => x.Value, x => x.Template.FileName);
      }
    
    }
