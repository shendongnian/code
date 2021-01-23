    private IList<CodeProperty> GetProperties(string csFile)
    {
      ProjectItem projectItem = TransformationContext.FindProjectItem(csFile);
      FileCodeModel codeModel = projectItem.FileCodeModel;
      var propertyList = new List<CodeProperty>();
      FindProperties(codeModel.CodeElements, propertyList);
      return propertyList;
    }
    private void FindProperties(CodeElements elements, IList<CodeProperty> properties)
    {
      foreach (CodeElement element in elements)
      {
        CodeProperty property = element as CodeProperty;
        if (property != null)
        {
          properties.Add(property);
        } 
        FindProperties(element.Children, properties);
      }
    }
