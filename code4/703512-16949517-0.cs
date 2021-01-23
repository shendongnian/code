    Employee objE = new Employee();
    var members = objE.GetType().GetFields().Select(m => new
    {
        Name = m.Name,
        MemType = m.MemberType,
        RtField = m.GetType(),
        Type = m.FieldType,
        MemAtt = m.GetCustomAttributes(true)
    });
