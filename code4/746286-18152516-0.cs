    tasks.Add(Task<IEnumerable<Items>>.Factory.ContinueWhenAll(results.ToArray(), 
    myTasks => 
    {
      var newList = new List<object>();
      foreach (var i in results)
       {
         newList.AddRange(i.Result);
       }
       return DoSomething(newList.AsEnumerable(),);
    }));
