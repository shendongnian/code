        public void SavePersons(IList<Person> persons)
        {
            // Create a EF Context
            using (var ctx = new MyDbEntities())
            {
                // Iterate
                foreach (var person in persons)
                {
                    // Get current keywords
                    var keywords = new List<Keyword>(person.Keywords).ToList();
                    // Fetch Person from DB (if its not a NEW entry). Must use Include, else it's not working.
                    var newPerson = ctx.Persons
                                           .Include("Keywords")
                                           .FirstOrDefault(s => s.Id == person.Id) ?? person;
                    // Clear keywords of the object, else EF will INSERT them.. Silly.
                    newPerson.Keywords.Clear();
                    // Insert or update?
                    ctx.Entry(newPerson).State = newPerson.Id == 0 ? EntityState.Added : EntityState.Modified;
                    // Apply new scalar values
                    if(newPerson.Id != 0)
                    {
                        person.Id = newPerson.Id;
                        ctx.Entry(newPerson).CurrentValues.SetValues(person);
                    }
                    // Iterate through all keywords
                    foreach (var kw in ctx.Keywords)
                    {
                        // If the current kw exists in OUR list, add it
                        // - if not, remove the relation from the DB.
                        if (keywords.Any(k => k.Id == kw.Id))
                        {
                            //ctx.Entry(kw).State = EntityState.Unchanged;
                            ctx.Keywords.Attach(kw);
                            newPerson.Keywords.Add(kw);
                        }
                        else
                            newPerson.Keywords.Remove(kw);
                    }
                }
                // Save
                ctx.SaveChanges();
            }
        }
