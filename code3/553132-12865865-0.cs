    private Dictionary<Type, int> myDictionary = new Dictionary<Type, int>();
    public void Add(Type type, int number) {
       if (!BaseClass.IsAssignableFrom(type)) throw Exception();
       myDictionary.Add(type, number);
    }
