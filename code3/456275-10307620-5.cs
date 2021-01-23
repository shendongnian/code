    static class EmailTemplateExtensions {
    
      static Dictionary<EmailTemplate, String> templates;
    
      static EmailTemplateExtensions() {
        templates = GetEnumAttributes<EmailTemplate, TemplateAttribute>()
          .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2.FileName);
      }
    
      public static String FileName(this EmailTemplate emailTemplate) {
        String fileName;
        if (templates.TryGetValue(emailTemplate, out fileName))
          return fileName;
        throw new ArgumentException(
          String.Format("No template defined for EmailTemplate.{0}.", emailTemplate)
        );
      }
    
    }
