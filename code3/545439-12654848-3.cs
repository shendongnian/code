    class Role
    {
        public string RoleID { get; set; }
        public string Rolecode { get; set; }
        public string Rolename { get; set; }
    }
    IEnumerable<Role> source = ...;
    Dictionary<string, Dictionary<string, List<string>>> result = source
        .GroupBy(r => r.RoleID)
        .ToDictionary(g => g.Key,
             g => g.GroupBy(r2 => r2.Rolecode)
            .ToDictionary(g2 => g2.Key,
                g2 => g2.Select(r3 => r3.Rolename).ToList())
        );
    // Rolecode unique
    Dictionary<string, Dictionary<string, string>> result2 = source
        .GroupBy(r => r.RoleID)
        .ToDictionary(g => g.Key,
            g => g.ToDictionary(r2 => r2.Rolecode, r2 => r2.Rolename)
        );
