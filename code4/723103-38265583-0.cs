    public object ConstructDictionary(Type KeyType, Type ValueType)
    {
        Type[] TemplateTypes = new Type[]{KeyType, ValueType};
        Type DictionaryType = typeof(Dictionary<,>).MakeGenericType(TemplateTypes);
        return Activator.CreateInstance(DictionaryType);
    }
    public void AddToDictionary(object DictionaryObject, object KeyObject, object ValueObject )
    {
        Type DictionaryType = DictionaryObject.GetType();
        if (!(DictionaryType .IsGenericType && DictionaryType .GetGenericTypeDefinition() == typeof(Dictionary<,>)))
            throw new Exception("sorry object is not a dictionary");
        Type[] TemplateTypes = DictionaryType.GetGenericArguments();
        var add = DictionaryType.GetMethod("Add", new[] { TemplateTypes[0], TemplateTypes[1] });
        add.Invoke(DictionaryObject, new object[] { KeyObject, ValueObject });
    }
    
