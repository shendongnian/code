        public class StudentsBase
        {
             public List<Students> Students;
        }
    
        public class Students : StudentsBase
        {
            public Students() 
            {
                Students = new List<Students>();
                Students.Add(new Students());
                Students.Add(new Students());              
            }
        }
