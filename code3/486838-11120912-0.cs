        public void InsertList(List<Person> people)
        {
            foreach (var person in people)
            {
                DoInsert(person); 
                // You can use the returned flag and implement the logic if desired.
                // Or let the loop move on its ways.
            }
        }
        public bool DoInsert(Person person)
        {
            try
            {
                using (DataModelDataContext dataContext = new DataModelDataContext())
                {
                    dataContext.Persons.InsertOnSubmit(person);
                    dataContext.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
