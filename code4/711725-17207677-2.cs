    public class MyCustomQueryResult
    {
        public int SomeId;
        public string SomeStringField;
        public int SomeScalar;
        public CSList<MappedObject> MappedObjects
        {
            get { return MappedObject.List("SomeId = @SomeId", "@SomeId", SomeId); }
        }
    }
