    // assuming XDocument xdoc = ...
    var records = from r in xdoc.Root.Elements("record")
                  select new Record
                  {
                      Name = (string)r.Element("name"),
                      Skills = (from s in r.Element("skills").Elements("skill")
                                select new Skill
                                {
                                    SkillName = (string)s.Element("skillname"),
                                    SkillType = (string)s.Element("skilltype")
                                }).ToList()
                  };
