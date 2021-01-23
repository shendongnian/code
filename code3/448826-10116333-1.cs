    public class Student
    {
       // existing date, don't expose this
       public DateTime TimeAdded;
       // expose this instead
       [DataMember(Name = "TimeAddedString")]
       public string TimeAddedString 
       {
          //show as "Monday, January 01, 0001 12:00 AM"
          get { return this.TimeAdded.ToString("f"); }
       }
    }
