    public class MyCriteria
    {
       public Guid Id {get;set;}
       public string Name {get;set;}
        //etc
     }
     public interface Repository
      {
           MyModel GetModel(Expression<Func<MyCriteria,bool>> criteria);
       }
