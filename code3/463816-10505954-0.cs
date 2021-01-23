    var lst = table.AsEnumerable().Select(r =>
        new MyObject
        {
            FirstProperty = r.Field<int>("FirstProperty"),
            OtherProperty = r.Field<string>("OtherProperty")
        }).ToList(); 
