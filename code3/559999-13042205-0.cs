        public static Person PersistPerson(Person person)
        {
            using (SystemEntities context = ConnectionManager.Instance.GetContext())
            {
                bool doInsert = false;
                var p = context.People.Where(d => d.PersonId == person.PersonId).FirstOrDefault();
                if (p == null)
                {
                    p = new Person();
                    doInsert = true;
                }
                //update connected Entity
                p.LastName = person.LastName;
                p.Emails = person.Emails;
                //etc...
                if(doInsert)                    
                    context.People.AddObject(person);
                context.SaveChanges();
                person.PersonId = p.PersonId;
            }
            return person;
        }
