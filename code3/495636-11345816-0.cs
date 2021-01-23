    string request = ...
    Dictionary<string,string> param = new Dictionary<string,string>();
    request.Split('&')
           .Select(o => o.Split('='))
           .ToList()
           .ForEach(p => param.Add(p[0],p[1])
    );
         
