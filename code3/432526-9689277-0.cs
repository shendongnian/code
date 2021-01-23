    class DataProvider
    {
       public System.Collections.IEnumerable<Result> PerformQuery(string param1, string param2)
       {
           var m_queryRes = DataAccessor.GetResults(param1, param2);
           foreach(var res in m_queryRes)
           {    
                  Result result = new Result();
                  result.Name = res.FirstName + res.SecondName;
                  result.Code = res.Code + "Some business logic";
                  yield return result;            
           }
       }
    }
    class Result
    {
       Property Name;
       Property Code;
    }
