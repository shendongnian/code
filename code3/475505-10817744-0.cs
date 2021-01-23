    static string Default = "99";
    static Dictionary<string, string> Cache = new Dictionary<string,string>(){
        {"00", "14"},
        {"1F", "11"},
        {"04", "10"},
        {"05", "09"},
        //etc
    }
    public static getType(Content this, string typeId){
        if(Cache.ContainsKey(typeId)) return Cache[typeId];
        else return Default;
    }
    //Add other types as needed
