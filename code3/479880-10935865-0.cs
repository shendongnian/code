    var sons = fathers.Select(f => f.Sons);
    if(includeSpeaksFrench) sons = sons.Where(son => son.Skills.Any(skill => skill.SkillType == "Languages" && skill.Name == "French"));
    if(includePlaysFootbal) sons = sons.Where(son => son.Skills.Any(skill => skill.SkillType == "Sport" && skill.Name == "Footbal"));
    ...etc...
    // we need to assume some sort of formal father-son relationship
    var persons = from son in sons
                  group son by new {son.Father.ID, son.Father.Name} into g
                  select new
                  {
                    g.Key.Name,
                    g.Count()
                  };
