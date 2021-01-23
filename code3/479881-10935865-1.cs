    var sons = fathers.Select(f => f.Sons);
    foreach(Skill skillCriterion in CriterionSkills)
    {
        sons = sons.Where(son => son.Skills.Any(skill => skill.SkillType == skillCriterion.SkillType && skill.Name == skillCriterion.Name));
    }
    
    // we need to assume some sort of formal father-son relationship
    var persons = from son in sons
                  group son by new {son.Father.ID, son.Father.Name} into g
                  select new
                  {
                    g.Key.Name,
                    g.Count()
                  };
