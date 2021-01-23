    XElement root = XElement.Load(filePath);
    var list = root.Elements().Select(x => new
        {
            FirstName = x.Get("PractitionerFirstName", string.Empty),
            LastName = x.Get("PractitionerLastName", string.Empty),
            NPI = x.Get("PractitionerNPI", string.Empty),
            Degree = x.Get("PractitionerDegree", string.Empty)
        }).ToArray();
