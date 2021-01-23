    public T[] Items{
        get{
            return ItemList.ToArray();
        }
        set{
            ItemList.Clear();
            ItemList.AddRange(value);
        }
    }
    
    [ScriptIgnore]
    public List<T> ItemList {get;set;}
