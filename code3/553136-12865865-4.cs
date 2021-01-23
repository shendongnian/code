    private Dictionary<Type, int> myDictionary = new Dictionary<Type, int>();
    public void Add(Type type, int number) {
       if (!typeof(BaseClass).IsAssignableFrom(type)) throw new Exception();
       myDictionary.Add(type, number);
    }
