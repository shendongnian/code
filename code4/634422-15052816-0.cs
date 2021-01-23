    class School
        {
            public string name;
            List<Student> Students = new List<Student>();
    
            ...
            public override string ToString()
            {
               var stringValue = name;
               foreach(var student in Students)
               {
                  stringValue += student.ToString();
               }
            }
        }
    class Student
    {
        public int Age;
        public string Name;
       ...
        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Age);
        }
    }
