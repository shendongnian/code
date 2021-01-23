    public class Student
    {
       public string TimeAddedString
       {
          get 
          { 
              return this.TimeAdded.ToString("dd/MM/yyyy hh:mm:ss"); 
              // your desired format can goes here
          } 
       }
    }
    public void AddStudent(Student student)
    {
        student.StudentID = (++eCount).ToString();
        student.TimeAdded = DateTime.Now; // or your desired datetime
        students.Add(student);
    }
