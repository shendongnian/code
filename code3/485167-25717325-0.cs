    public class CustomTableEntity : TableEntity
    {
        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            base.ReadEntity(properties, operationContext);
            foreach (var thisProperty in
                GetType().GetProperties().Where(thisProperty =>
                    thisProperty.GetType() != typeof(string) &&
                    properties.ContainsKey(thisProperty.Name) &&
                    properties[thisProperty.Name].PropertyType == EdmType.String))
            {
                var parse = thisProperty.PropertyType.GetMethods().SingleOrDefault(m =>
                    m.Name == "Parse" &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(string));
                var value = parse != null ?
                    parse.Invoke(thisProperty, new object[] { properties[thisProperty.Name].StringValue }) :
                    Convert.ChangeType(properties[thisProperty.Name].PropertyAsObject, thisProperty.PropertyType);
                thisProperty.SetValue(this, value);
            }
        }
        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var properties = base.WriteEntity(operationContext);
            foreach (var thisProperty in
                GetType().GetProperties().Where(thisProperty =>
                    !properties.ContainsKey(thisProperty.Name) &&
                    typeof(TableEntity).GetProperties().All(p => p.Name != thisProperty.Name)))
            {
                var value = thisProperty.GetValue(this);
                if (value != null)
                {
                    properties.Add(thisProperty.Name, new EntityProperty(value.ToString()));
                }
            }
            return properties;
        }
    }
