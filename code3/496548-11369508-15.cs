    public class CustomModelMetaDataProvider : DataAnnotationsModelMetadataProvider
    {
    	protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
    	  Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
    	{
    	  var displayColumnAttribute = new List<Attribute>(attributes).OfType<DisplayColumnAttribute>().FirstOrDefault();
    
    	  var baseMetaData = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
    
    	  return new CustomModelMetaData(this, containerType, modelAccessor, modelType,  propertyName, displayColumnAttribute)
    	  {
    		TemplateHint = baseMetaData.TemplateHint,
    		HideSurroundingHtml = baseMetaData.HideSurroundingHtml,
    		DataTypeName = baseMetaData.DataTypeName,
    		IsReadOnly = baseMetaData.IsReadOnly,
    		NullDisplayText = baseMetaData.NullDisplayText,
    		DisplayFormatString = baseMetaData.DisplayFormatString,
    		ConvertEmptyStringToNull = baseMetaData.ConvertEmptyStringToNull,
    		EditFormatString = baseMetaData.EditFormatString,
    		ShowForDisplay = baseMetaData.ShowForDisplay,
    		ShowForEdit = baseMetaData.ShowForEdit,
    		Description = baseMetaData.Description,
    		ShortDisplayName = baseMetaData.ShortDisplayName,
    		Watermark = baseMetaData.Watermark,
    		Order = baseMetaData.Order,
    		DisplayName = baseMetaData.DisplayName,
    		IsRequired = baseMetaData.IsRequired
    	  };
    	}
    }
