    public class PersonCm : Person
    {
        public new string Course
        {
          get
          {
            return base.Course;
          }
          set
          {
            base.Course = value;
            this.PropertyChanged("Course"); // should fix it
          }
    }
