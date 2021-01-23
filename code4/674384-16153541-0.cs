    public static IEnumerable<string> GetCorrectedRoleNames(IEnumerable<string> roles)
    {
        List<string> correctedRoles = new List<string>();
        foreach (string role in roles)
            correctedRoles.Add(Regex.Replace(role, "Sub", string.Empty));
        return correctedRoles.AsEnumerable();
    }
