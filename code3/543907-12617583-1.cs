    public class ViewModel 
    {
        private List<FreshmenClass> currentClass;
        public ViewModel()
        {
            CurrentClass = new List<FreshmenClass>();
            FreshmenClass temp = new FreshmenClass();
            temp.Year = "2001";
            temp.Students.Add(new Student("Student1", "LastName1"));
            temp.Students.Add(new Student("Student2", "LastName2"));
            CurrentClass.Add(temp);
        }
        public List<FreshmenClass> CurrentClass
        {
            get { return currentClass; }
            set { currentClass = value; }
        }
    }
