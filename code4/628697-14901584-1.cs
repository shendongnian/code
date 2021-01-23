    public class Toop {
         // These values are *fields* within the class, but *not* "properties." 
         private string m_Rang; // changing these field decls to include m_ prefix for clarity
         private int m_Gheymat; // also changing them to private, which is a better practice
         // This is a public *property* procedure
         public string Rang     
         {
             get
             {
                 return m_Rang;
             }
             set
             {
                 m_Rang = value;
             }
         }
    }
