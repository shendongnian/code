    Dictionary<string,List<int>> MyList;
    void AddItem(string key, int value){
    List<int> values;
    if(!MyList.TryGet(key, values)){
    values= new List<int>();
    MyList.Add(key, values);
    }
    values.Add(value);
    }
