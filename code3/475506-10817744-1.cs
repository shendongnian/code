    static string Default = "99";
    public static readonly Dictionary<string, string> Cache = new Dictionary<string,string>(){
        {"00", "14"},
        {"1F", "11"},
        {"04", "10"},
        {"05", "09"},
        //etc
    }
    public static getType(Content this){
        if(Cache.ContainsKey(this.typeId)) return Cache[this.typeId];
        else return Default;
    }
    //Add other types as needed
