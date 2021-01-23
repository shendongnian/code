    abstract class User
    {
        public virtual UserType Type { get; protected set;}
    }
    
    class Teacher : User
    {
        public Teacher()
        {
            Type = UserType.Teacher;
        }
    }
    class LabEmployee : User
    {
        public LabEmployee()
        {
            Type = UserType.LabEmployee;
        }
    }
    switch(someuser.Type)
