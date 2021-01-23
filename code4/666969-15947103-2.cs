    public String ProcessTemplate(String templateName, dynamic variables)
    {
        String template = MethodThatSearchOnResourceAndReturnsTemplateByItsName(templateName);
            if (String.IsNullOrWhiteSpace(template))
            {
                return String.Empty;
            }
            if (variables == null)
            {
                return template;
            }
            PropertyInfo[] properties = ((Object)variables).GetType().GetProperties();
            foreach (PropertyInfo prop in properties )
            {
                template = template.Replace("[" + prop.Name + "]", propriedade.GetValue(properties, null));
            }
            return template;
     }
