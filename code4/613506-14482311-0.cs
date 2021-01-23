                using (var con = new PersonDataModelContainer())
                {
                    var pers = new Person() { Id = PersonId };
    
                    int pId = 0;
                    if (pers.PersonId > 0)
                    {
                        pers = con.Persons.FirstOrDefault(c => c.PersonId == pers.PersonId);
                        pId = pers.pId;
                    }
                    else
                        pId = con.Users.NextId(c => c.PersonId) + 1;
    
                    if (pers.UserId == 0)
                        con.Persons.AddObject(pers);
                    con.SaveChanges();
                    pId = Persons.PersonId;
    
    
                    var prof = new Profession() { Id = ProfessionId, PersonId = pId };
    
                    int profId = 0;
                    if (prof.PersonId > 0)
                    {
                        prof = con.Professions.FirstOrDefault(c => c.ProfessionId == prof.ProfessionId);
                        profId = prof.PersonId;
                    }
                    else
                        profId = con.Professions.NextId(c => c.ProfessionId) + 1;
    
                    if (prof.ProfessionId == 0)
                        con.Professions.AddObject(prof);
                    con.SaveChanges();
                    prof.ProfessionId = profId;
                }
