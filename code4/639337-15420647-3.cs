     public Person CreatePerson(string name, string username) {
         Person person = new Person { Name = name };
         _dbContext.Person.add(person);
         _dbContext.SaveChanges();
         
         var membership = (SimpleMembershipProvider)Membership.Provider;
         membership.CreateUserAndAccount(
             model.UserName, 
             createRandomPassword(), 
             new Dictionary<string, object>{ {"PersonId" , person.Id}}
         );
                    
     }
