    public class Student 
    {
        public override bool Equals(object x) 
        {
            return ((Student)x).Id == this.Id;
        }
    }
    if (!students.Contains(student)) 
    {
       students.Add(student);
    } 
    else 
    {
         throw new ArgumentException("Error student " 
                  + student.Name + " is already in the class");
    }
