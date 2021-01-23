    class ListModel {
       public string this[string key] { get{return _values[key];} set{_values[key]=value;}}
       public int ID{get;set;}
       public IDictionary<string,string> _values = new Dictionary<string,string>();
    }
