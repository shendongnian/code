        // get unique list of Keywords from all Persons
        private List<Keyword> cloneKeywordsUnique(IEnumerable<Person> oxygenThiefs) {
            var result = new List<Keyword>();
            
            foreach (var thief in oxygenThiefs) {
                foreach (var keyword in thief.Keywords) {
                    if (!result.Contains(keyword)) {
                        result.Add(keyword);
                    }
                }
            }
            return result;
        }
        // shallow clone of Person
        private Person clonePerson(Person target) {
            return new Person {
                Id = target.Id,
                Name = target.Name,
                ..
                ..
            };
        }
        public void SavePersons(IList<Person> persons) {
            // Create a EF Context
            using (var ctx = new MyDbEntities()) {
                // add all Keywords to the Context so that they are tracked
                foreach (var keyword in cloneKeywordsUnique(persons)) {
                    ctx.Keywords.Attach(keyword);
                    // if value of Keyword has actually changed then uncomment line
                    // ctx.Entry(keyword).State = EntityState.Modified
                }
                foreach (var person in persons) {
                    // hehe
                    var shallowPerson = clonePerson(person);
                    // Attach Person
                    ctx.Persons.Attach(shallowPerson);
                    // Establish relationship (however shallow and meaningless)
                    foreach (var keyword in person.Keywords) {
                        shallowPerson.Keywords.Add(keyword);
                    }
                    // Insert or update?
                    ctx.Entry(shallowPerson).State = person.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
                // Save
                ctx.SaveChanges();
            }
        }
