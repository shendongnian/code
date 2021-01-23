    public class ColumnMapping
    {
        public ColumnMapping(string columnName, int columnIndex, EntityProperty entityProperty, List<EntityProperty> entityProperties)
        {
            ColumnName = columnName;
            ColumnIndex = columnIndex;
            EntityProperty = entityProperty;
            EntityProperties = entityProperties;
        }
        public string ColumnName { get; private set; }
        public int ColumnIndex { get; private set; }
        public EntityProperty EntityProperty { get; set; }
        public List<EntityProperty> EntityProperties { get; private set; }
    }
    public class EntityProperty
    {
        public EntityProperty(string displayName, string name)
        {
            DisplayName = displayName;
            Name = name;
        }
        public string DisplayName { get; private set; }
        public string Name { get; private set; }
    }
