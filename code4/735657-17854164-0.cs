    var interfaces = (typeof(Test)).GetInterfaces();
    var p = typeof(Test).GetProperties(
        BindingFlags.Instance |
        BindingFlags.NonPublic);
    var result = interfaces.SelectMany(i => i.GetMembers())
            .Select(m =>
            {
                var name = m.DeclaringType.FullName +"."+ m.Name;
                Console.WriteLine(name);
                return name;
            })
            .Intersect(p.Select(m =>
            {
                Console.WriteLine(m.Name);
                return m.Name;
            }))
            .ToList();
