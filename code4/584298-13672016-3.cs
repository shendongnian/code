    public class AbstractJobDao<T> where T : IJob {
      public AbstractJobDao(IJobFactory<T> factory)
      {
      }
    
      protected IJobFactory<T> Factory{get;set;}
    
      protected T buildJob() {
        return Factory.Create();
      }      
    }
    
    public class FullTimeJobDao : AbstractJobDao<FullTimeJob> {
    
      public FullTimeJobDao()
        : base(new FullTimeJobFactory())
      {}     
    }
    
    public class InternshipDao : AbstractJobDao<Internship> {
      public InternshipDao ()
        : base(new InternshipJobFactory())
      {}
          
    }
