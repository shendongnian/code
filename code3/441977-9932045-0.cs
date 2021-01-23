    interface IFactory<TConfiguration,TProblem> 
              where TProblem: IProblem
              where TConfiguration: IConfiguration
    {
       TProblem Create(TConfiguration config);
    }
    
    class Factory<TConfiguration,TProblem>: IFactory<TConfiguration,TProblem>
              where TProblem: IProblem
              where TConfiguration: IConfiguration
    {
       TProblem Create(TConfiguration config)
       {
           var problem = new Problem(config);
           ...
           return problem;
       }
    }
