    public class NodaCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        public NodaCollectionEditor(Type collection_type) : base(collection_type) { }
        protected override object CreateInstance(Type itemType)
        {
            if (itemType == typeof(LocalDate))
                return LocalDateHelper.MinValue;
            else 
                return base.CreateInstance(itemType);
        }
    }
