        public class Person2Bl
        {
            // Functionality which is common for all the inheritance chain of entities
            public void PrintAdresses(Person person)
            {
            }
            public void SaveAdresses(Person person)
            {
               // specific for person
            }
            // Functionality specific of person
            public void DoSomethingWithPerson(Person person)
            {
            }
        }
        // doesn't inherit:
        public class Worker2Bl
        {
            // Use the logic in PersonBl2
            public void PrintAdresses(Worker worker)
            {
                // Really not necessary -> this could be done directly in the app code
                Person2Bl bl = new Person2Bl();
                bl.PrintAdresses(worker);
            }
            public void SaveAdresses(Worker worker)
            {
               // specific of Worker
            }
            public void DoSomethingWithWorker(Worker worker)
            {
                // specific of worker
            }
        }
