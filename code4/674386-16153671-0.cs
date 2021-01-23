    List<string> x = new List<string>();
    x.Add("SubUser");
    x.Add("SubAdmin");
    x.Add("SubManager");
    
    var m = x.Select( y => y.Replace("Sub", ""));
