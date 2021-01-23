    public class Student : IValidatableEntity
    {
        public virtual Teacher Teacher { get; set; }
        public void Validate()
        {
            if (this.Teacher.Students.Count() > this.Teacher.MaxStudents)
            {
                throw new CustomException("Too many students!");
            }
        }
    }
