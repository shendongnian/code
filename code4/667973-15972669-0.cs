    List<string> val = new List<string>();
    val.Add("A");
    val.Add("B");
    val.Add("C");
    
    string res = string.Join(", ", from item in val select item); 
