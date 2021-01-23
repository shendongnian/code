    public class AbstractJobDao<T> where T : IJob {
      protected T buildJob() {
        // i want to create an IJob instance based on the generic parameter
        return default(T);
      }      
    }
    
    public class FullTimeJobDao : AbstractJobDao<FullTimeJob> {      
    }
    
    public class InternshipDao : AbstractJobDao<Internship> {      
    }
