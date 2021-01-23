    public sealed class PartFactory
    {
        private Dictionary<Type, IPartCreator> creators_ = new Dictionary<Type, IPartCreator>();
        // registration (note, we use the type system!)
        public void RegisterCreator<T>(IPartCreator creator) where T : IPart
        {
            creators_[typeof(T)] = creator;
        }
        public T CreatePart<T>() where T: IPart
        {
            if(creators_.ContainsKey(typeof(T))
                return creators_[typeof(T)].Create();
            return default(T);
        }
    }
