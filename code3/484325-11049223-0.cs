    public class UniqueIntGenerator : IIdGenerator
    {
        private static UniqueIntGenerator _instance;
        public static UniqueIntGenerator Instance { get { return _instance; } }
        static UniqueIntGenerator()
        {
            _instance = new UniqueIntGenerator();
        }
        public object GenerateId(object container, object document)
        {
            var cont = container as MongoCollection;
            if (cont == null)
                return 0;
            var type = cont.Settings.DefaultDocumentType;
            var cursor = cont.FindAllAs(type);
            cursor.SetSortOrder(SortBy.Descending("_id"));
            cursor.Limit = 1;
            foreach (var obj in cursor)
                return GetId(obj) + 1;
            return 1;
        }
        private int GetId(object obj)
        {
            var properties = obj.GetType().GetProperties();
            var idProperty = properties.Single(y => y.GetCustomAttributes(typeof(BsonIdAttribute), false).SingleOrDefault() != null);
            var idValue = (int)idProperty.GetValue(obj, null);
            return idValue;
        }
        public bool IsEmpty(object id)
        {
            return default(int) == (int)id;
        }
    }
