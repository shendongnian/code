    public class MembershipRepository
    {
       public List<string> GetMembers()
       {
         var gateway = new DatabaseGateway();
         var transformer = new MemberRowTransformer();
         var result = new List<string>();
    
         foreach (string i in gateway.RetrieveSqlAs("SELECT members FROM  dbo.tbl_Category", transformer))
         {
           result.Add(i);
         }
         
         return result;
       }
    }
