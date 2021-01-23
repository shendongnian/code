    public class StudentCollection : List<Student>
    {
       public void ChangeId(Student student, int newId) 
       {
          if(students.Where(s => s.Id == newId).Count() > 0)
             throw new ArgumentException("A student already has that Id");
    
          student.Id = newId;
       }
    }
