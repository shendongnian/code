    var myData = ds.Tables[0].AsEnumerable().Select(r => new Employee {
        Name = r.Field<string>("Name"),
        Age = r.Field<int>("Age")
    });
    var list = myData.ToList(); // For if you really need a List and not IEnumerable
