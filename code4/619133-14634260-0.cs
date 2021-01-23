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
		            // ... I think this is stupid.
                    var newPerson = ctx.Persons.Include("Keywords").FirstOrDefault(p => p.Id == person.Id) ?? person;
                    // Insert or update?
                    ctx.Entry(newPerson).State = newPerson.Id == 0 ? EntityState.Added : EntityState.Modified;
                    // Apply new scalar values
                    ctx.Entry(newPerson).CurrentValues.SetValues(person);
                    // Clear keywords
                    newPerson.Keywords.Clear();
                    // Add keywords
                    keywords.ForEach(kw =>
                                         {
                                             // Keyword needs to be attached to the context, else 
                                             // EF thinks it's a new entity, and performs an INSERT on the
					                         // keyword, we dont want that.
                                             ctx.Keywords.Attach(kw);
                                             newPerson.Keywords.Add(kw);
                                         });
                    
                }
                
                // Save
                ctx.SaveChanges();
            }
        }
