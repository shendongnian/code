    Dictionary<string, string> dic = new Dictionary<string, string>();
    dic.Add("userOne", "Admin access");
    
    string access = string.Empty;
    dic.TryGetValue("userOne", out access);
