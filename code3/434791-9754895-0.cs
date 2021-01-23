    protected string GetName(string code)
    {
        var item = XElement.Load("XMLfile1.xml").GetEnumerable("test", x =>
                new
                {
                    Code = x.Get("code", string.Empty),
                    Name = x.Get("name", string.Empty)
                })
                .FirstOrDefault(i => i.Code == code);
        if(null != item)
            return item.Name;
        return "Item not found";
    }
