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
                id = user.Id;
            }
            // After some time in other some place
            //pause here and insert the id GUID into the Person table
            using (var db = new MainDataContext())
            {
                var person = db.Persons.Find(id);
                person.FirstName = "someFirstName";
                person.LastName = "someLastName";
                db.SaveChanges();
            }
