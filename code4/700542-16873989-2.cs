    public class MyDataAnnotationsModelMetadataProvider : 
        System.Web.Mvc.DataAnnotationsModelMetadataProvider
    {
        protected override System.Web.Mvc.ModelMetadata 
            CreateMetadata(IEnumerable<Attribute> attributes, 
                Type containerType, 
                Func<object> modelAccessor, 
                Type modelType, 
                string propertyName)
        {
            if (containerType == typeof(Contact))
            {
                // get the repository instance  
                var db = new MyModelEntities();
                // find the current textbox by it's property name
                var textBox = db.TextBoxes
                    .FirstOrDefault(t => t.TextBoxName == propertyName);
                if (!string.IsNullOrWhiteSpace(propertyName) && textBox != null)
                    attributes = attributes.Union(new List<Attribute>() {
                        new DisplayAttribute() { Order = textBox.Ordinal } 
                    });
            }
            return base.CreateMetadata(attributes, 
                containerType, 
                modelAccessor, 
                modelType, 
                propertyName);
        }
    }
