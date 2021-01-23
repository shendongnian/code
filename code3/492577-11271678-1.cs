    if(MyPerson != null)
    {
      var q = SessionInstance.Query<Identity>()
           .Count(x => x.Person != null && x.Person.Id == MyPerson.Id);
    }else
    {
      // if you know when MyPerson is null count is zero, why you need to Query?
      // here count is zero..
    
    }
