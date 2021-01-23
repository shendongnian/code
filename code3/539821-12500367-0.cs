    Dictionary<string,string> dict = new Dictionary<string,string>();
    dict.Add("BNo", "12");
    dict.Add("CNo", null);
    dict.Add("ANo", null);
    dict.Add("DNo", null);
    dict.Add("ENo", "16");
    Debug.WriteLine(dict.OrderBy(o => o.Key).FirstOrDefault(d => d.Value != null));
