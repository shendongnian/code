    var query = from father in fathers
                from son in father.Sons
                select new {father, son};
    foreach (Skill skillCriterion in CriterionSkills)
    {
        query = query.Where(fs => fs.son.Skills.Any(
            skill => skill.SkillType == skillCriterion.SkillType && 
                     skill.Name == skillCriterion.Name));         
    }         
    var persons = from fs in query
                  group fs by fs.father into g 
                  select new                                 
                  { 
                     Count = g.Count(),
                     Name = g.Key.Name
                  };
