    public class Gateway
    {
        public void DoSomethingWithPerson(IPerson person)
        {
            string id = person.getID();
            if (person is Student)
            {
                // do stuff for student, even cast is possible (Student) person
            }
            else if (person is Staff)
            {
                // do stuff for staff, even cast is possible (Staff) person
            }
        }
    }
