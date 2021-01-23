     public class StudenData {
         public string name { get;set; }
         public int rollNo {get;set; }
         public string grade { 
             get { return gpaEnum.ToString(); }
             set { gpaEnum = (grading)Enum.Parse(typeof(grading),value); }
         public gpaEnum { get;set; }
         public int gpa {
             get { return (int)gpaEnum; }
             set { gpaEnum=(grading)value; }
         }
     }
