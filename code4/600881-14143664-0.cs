    public class EnsureEnrollment : ValidationAttribute
    {
        public EnsureEnrollment () {    }
        public override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var studentList = value as IEnumerable<Student>;
            if (studentList == null)
            {
                return ValidationResult.Success;
            }
            foreach(Student s in studentList )
            {
                if(!s.IsEnrolled)
                {
                    //Insert whatever error message you want here.  
                    return new ValidationResult("Student \"" + s.Name + "\" is not enrolled.");
                }
            }
            return ValidationResult.Success;
        }
    }
