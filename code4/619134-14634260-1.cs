        public void SavePersons(IList<Person> persons)
        {
            // Create a EF Context
            using (var ctx = new MyDbEntities())
            {
                foreach (var person in persons)
                {
                    // Get current keywords
                    var keywords = new List<Keyword>(person.Keywords).ToList();
                    // Fetch Person from DB (if its not a NEW entry). Must use Include, else it's not working.
                    var newPerson = ctx.Persons
                        .Include("Keywords")
                        .FirstOrDefault(p => p.Id == person.Id) 
                        ?? person;
                    // Insert or update?
                    ctx.Entry(newPerson).State = newPerson.Id == 0 ? EntityState.Added : EntityState.Modified;
                    // Apply new scalar values
                    person.Id = newPerson.Id;
                    ctx.Entry(newPerson).CurrentValues.SetValues(person);
                    // Clear keywords
                    newPerson.Keywords.Clear();
                    // Iterate through all keywords
                    ctx.Keywords.ToList().ForEach(kw =>
                    {
                        // If the current kw exists in OUR list, add it
                        // - if not, remove the relation from the DB.
                        if (keywords.Any(k => k.Id == kw.Id))
                            newPerson.Keywords.Add(kw);
                        else
                            newPerson.Keywords.Remove(kw);
                    });
                }
                // Save
                ctx.SaveChanges();
            }
        }
