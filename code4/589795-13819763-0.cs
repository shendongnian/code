    UnitOfWork.Session.CreateCriteria<MyDto>().CreateAlias("Days", "days")  
       .Add(Restrictions.Between("days.DayDate", query.FromDate, query.ToDate))  
       .SetResultTransformer(  
              new NHibernate.Transform.DistinctRootEntityResultTransformer());  
    
