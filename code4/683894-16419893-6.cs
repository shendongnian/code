     public abstract class Person : IPerson
        {
            private string id;
            public Person(){}
            public Person(string i)
            {
                id = i;
            }
            public abstract void Update(Object o);
        }
        public class Student:Person
    {
        public Student(){}
        public Student(string i):base(i)
        {
        }
        public override void Update(object o)
        {
            //whatever you wanted to do with Student
        }
    }
    public class Staff : Person
    {
         public Staff(){}
         public Staff(string i)
             : base(i)
        {
        }
        public override void Update(object o)
        {
            //whatever you wanted to do with Staff
        }
    }    
        interface IPerson     //Observer interface
        {
            void Update(Object o);
    
        }
