        public class PersonBl
        {
            // Functionality which is common fot all the inheritance chain
            public void PrintAdresses(Person person)
            {
            }
            // Functionality that can be specialized for each inherited entity
            public virtual void SaveAdresses(Person person)
            {
                // they're are treated differently in each case
            }
            // Functionality specific of person
            public void DoSomethingWithPerson(Person person)
            {
                // TODO
            }
        }
        public class WorkerBl : PersonBl
        {
            // Uses PersonBl PrintAdresses
            public override void SaveAdresses(Person person)
            {
                // do it for worker
            }
            // Functionality specific of Worker
            public void DoSomethingWithWorker(Worker worker)
            {
                // TODO
            }
        }
