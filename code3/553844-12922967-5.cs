    public class Course
    {
        public int ID { set; get; }
        public string Name{ set; get; }
        public List<Option> Options{ set; get; }
        public int SelectedAnswer { set; get; }
        public Course()
        {
            Options= new List<Option>();
        }
    }
    public class Option
    {
        public int ID { set; get; }
        public string Title { set; get; }
    }
    public class OrderViewModel 
    {
        public List<Course> Courses{ set; get; }
        public OrderViewModel()
        {
            Courses= new List<Course>();
        }
    }
