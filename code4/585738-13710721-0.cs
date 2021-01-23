     public List<GetPersonResult> GetPeople()
     {
           return (from p in dbContext.People
                  select new GetPersonResult
                  {
                       UserName = p.Username,
                       EmailAddress = p.Email
                  }).ToList();
     }
     
     public class GetPersonResult
     {
           public string UserName{get;set;}
           public string EmailAddress{get;set;}
     }
