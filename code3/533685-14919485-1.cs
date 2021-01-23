      class AllItemsTypeConverter: ExpandableObjectConverter
        {
    
            public override PropertyDescriptorCollection GetProperties(
                ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
    
                var originalProperties = base.GetProperties(context, value, attributes);
                var propertyDescriptorList = new List<PropertyDescriptor>(originalProperties.Count);
                
                foreach (PropertyDescriptor propertyDescriptor in originalProperties)
                {
                    bool showPropertyDescriptor = true;
                    switch (propertyDescriptor.Name)
                    {
                        // this properties belong to Input
                        case "InputPlayInstance": showPropertyDescriptor = designerNode.ShowInput; break;
                        case "InputNodeInputSetup": showPropertyDescriptor = designerNode.ShowInput; break;
                        case "InputGrammerList": showPropertyDescriptor = designerNode.ShowInput; break;
  
    .
    .
    .
    .
                    }
    
                    if (showPropertyDescriptor) propertyDescriptorList.Add(propertyDescriptor);
                }
    
    
                return new PropertyDescriptorCollection(propertyDescriptorList.ToArray());
            }
        }
