    class Model
    {
        public string RoleID { get; set; }
        public string Rolecode { get; set; }
        public string Rolename { get; set; }
    }
    IEnumerable<Model> source = ...;
    // Rolename not unique
    Dictionary<string, Dictionary<string, List<string>>> result = source
        .GroupBy(c => c.RoleID)
        .ToDictionary(g => g.Key,
             g => g.GroupBy(c => c.Rolecode)
            .ToDictionary(g2 => g.Key,
                g2 => g2.Select(m => m.Rolename).ToList())
        );
    // Rolename unique
    Dictionary<string, Dictionary<string, string>> result2 = source
        .GroupBy(c => c.RoleID)
        .ToDictionary(g => g.Key,
            g => g.ToDictionary(c2 => c2.Rolecode, c2 => c2.Rolename)
        );
