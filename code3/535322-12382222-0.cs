    string strHTMLText=@"&lt;p&gt;Pellentesque habitant [[@Code1]] morbi tristique senectus [[@Code2]] et netus et malesuada fames ac [[@Code3]] turpis egestas.&lt;/p&gt;";
    
    IEnumerable<string> arr = strHTMLText.Split(new char[] {'['};
    List<string> output = new List<string>();
    foreach(var item in arr)
    {
    string placeHolder = item.Substring(0,item.IndexOf("]");
    output.Add(placeHolder);
    }
