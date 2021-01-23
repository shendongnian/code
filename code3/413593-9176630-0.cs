    public string value1
    {
       get{return values.Split('|')[0]}
       set{values = value + values.Remove(0, values.IndexOf('|')+1)}
    }
    public string value2 ....
    public string values ...
