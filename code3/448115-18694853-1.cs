    public class ModelBinderConfig
    {
        public static void Register(ModelBinderDictionary binder)
        {
            binder.Add(typeof(ObjectId), new ObjectIdBinder());
            binder.Add(typeof(string[]), new StringArrayBinder());
            binder.Add(typeof(int[]), new IntArrayBinder());
        }
    }
