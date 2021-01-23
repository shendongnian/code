        public void test() {
            
            // This line should work for grouping
            var groupedContacts = Contacts.GroupBy(contact => contact.LastName);
            foreach(var group in groupedContacts){
                string LastName = group.Key;
                if(LastName == null){
                    continue;
                }
                foreach(var person in group){
                    Console.WriteLine(person.FirstName);
                }
            }
        }
