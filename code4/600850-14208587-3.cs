            List<Person> GetPeople()
            {
                //ExpensesEntities ee = new ExpensesEntities();
                return ee.tePersons.Select(x => new Person
                                             {
                                                 PersonId = x.PersonID,
                                                 FirstName = x.FirstName
                                             }).ToList();
            }
    int ConvertToNumber(string s)
            {
                try
                {
                    return Convert.ToInt32(s);
                }
                catch (FormatException e)
                {
                    return 0;
                }
            }
    
            void SetCurrentUser()
            {
                int currentID = ConvertToNumber(CurrentUser);
    
                _currentPerson = ee.tePersons
                                   .Where(i => i.PersonID == currentID)
                                   .Select(p => new Person
                                                    {
                                                        PersonId = p.PersonID,
                                                        FirstName = p.FirstName
                                                    }).FirstOrDefault();
            }
