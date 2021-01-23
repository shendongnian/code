    public class CustomTableEntity : TableEntity
    {
        private const string DecimalPrefix = "D_";
        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            var entityProperties = base.WriteEntity(operationContext);
            var objectProperties = GetType().GetProperties();
            foreach (var item in objectProperties.Where(f => f.PropertyType == typeof (decimal)))
            {
                entityProperties.Add(DecimalPrefix + item.Name, new EntityProperty(item.GetValue(this, null).ToString()));
            }
            return entityProperties;
        }
    }
