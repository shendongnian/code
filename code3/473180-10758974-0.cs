    Dictionary<string, int> weight = new Dictionary<string, int>();
    weight.Add("Super", 30);
    weight.Add("Admin", 20);
    weight.Add("Guest", 10);
    
    string[] roles = Roles.GetRolesForUser(User.Identity.Name);
    if (roles.Any())
    {
      ViewBag.Role = weight.Where(w => roles.Contains(w.Key))
        .OrderBy(w => w.Value)
        .FirstOrDefault();
    }
    else
    {
      ViewBag.Role = 5;
    }
