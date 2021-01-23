    public class School{
       public int Id {get;set;}
       public string Name {get;set;}
    
       static private IEnumerable<School> school;
       static public IEnumerable<School> Schools(ContextDb context){
          if(school != null)
             return school;
    
          return(school = context.Schools.ToList());
       }
    
       public static void InvalidateSchools()
       { 
           school = null;
       }
    }
