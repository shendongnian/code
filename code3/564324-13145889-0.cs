    public class Student
    {
        private int id;
        public override bool Equals(object obj)
        {
            Student otherStudent = obj as Student;
            if (otherStudent !=null)
            {
                return this.id.Equals(otherStudent.id);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
