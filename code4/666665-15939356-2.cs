    partial class UserMail
    {        
        public string TruncatedSubject
        {
           get
           {
               return Subject.Length < 200? Subject : (Subject.SubString(0,200) + " ...");
           }
        }        
    }
