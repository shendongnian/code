    public class MyCustomQueryResult
    {
        public int SomeId;
        public string SomeStringField;
        public int SomeScalar;
        public CSList<MappedObject> MappedObjects
        {
            get { return MappedObject.Select("SomeId = @SomeId", "@SomeId", SomeId); }
        }
    }
