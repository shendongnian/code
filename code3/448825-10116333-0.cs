    public class Student
    {
       //existing props left out
       //show as "Monday, January 01, 0001 12:00 AM"
       public string TimeAddedString 
       {
          get { return this.TimeAdded.ToString("f"); }
       }
    }
