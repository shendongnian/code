    @model object
    @using System.Text;
    @using System.Data;
 
    @{
      ViewDataDictionary viewData = Html.ViewContext.ViewData;
      TemplateInfo templateInfo = viewData.TemplateInfo;
      ModelMetadata modelMetadata = viewData.ModelMetadata;
    
      System.Text.StringBuilder builder = new StringBuilder();
      string result;
      // DDB #224751
      if (templateInfo.TemplateDepth > 2) 
      { 
        result = modelMetadata.Model == null ? modelMetadata.NullDisplayText 
                                             : modelMetadata.SimpleDisplayText;
      }
      foreach (ModelMetadata propertyMetadata in modelMetadata.Properties
        .Where(pm => pm.ShowForEdit
               && pm.ModelType != typeof(System.Data.EntityState)
               && !templateInfo.Visited(pm))) 
      {
          builder.Append(Html.Editor(propertyMetadata.PropertyName).ToHtmlString());
      }
	
      result = builder.ToString();
    }
    @Html.Raw(result)
