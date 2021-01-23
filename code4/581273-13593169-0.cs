    XDocument xDoc = XDocument.Parse(xml);
    var list = xDoc.Descendants("record")
                .Select(r => new Record
                {
                    Name = (string)r.Element("name"),
                    Skills = r.Descendants("skill")
                                .Select(s=>new Skill{
                                    SkillName = (string)s.Element("skillname"),
                                    SkillType = (string)s.Element("skilltype"),
                                })
                                .ToList()
                })
                .ToList();
