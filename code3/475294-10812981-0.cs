    Dictionary<string, string> myDictionary = new Dictionary<string, string>();
    myDictionary.Add("a", "714");
    myDictionary.Add("b", "741");
    myDictionary.Add("c", "147");
    //and so on ...
    string tekstas = "abc";
    StringBuilder sb = new StringBuilder();
    foreach(char c in tekstas)
           {
             string key = c.ToString();
             sb.Append(myDictionary[key]);
             }
    var  pakeistas = sb.ToString();
