            Guid id;
            using (var db = new MainDataContext())
            {
                var user = new User
                {
                    Name = "someUser",
                    Password = "somePassword",
                    Email = "someEmail"
                };
                db.Users.Add(user);
                db.SaveChanges();
                // After some time in other some place
                id = user.Id;
            }
            //pause here and insert the GUID into the Person table
            using (var db = new MainDataContext())
            {
                var person = db.Persons.Find(id);
                person.FirstName = "someFirstName";
                person.LastName = "someLastName";
                //person.FirstName = "someFirstName";
                //person.LastName = "someLastName";
                //db.Persons.Add(person);
                db.SaveChanges();
            }
