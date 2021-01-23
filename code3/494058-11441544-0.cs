    public interface ILijosBankRepository
    {
        List<DBML_Project.BankAccount> GetAllAccountsForUser(int userID);
        void UpdateBankAccount(/* params go here */);
        /* ...other query methods, etc... */
    
    }
    public class LijosBankRepository : ILijosBankRepository
    {
         private readonly DataContext context { get; set;}
         public LijosBankRepository(DataContext ctx) { ... }
         
         public void UpdateBankAccount(string inputXml)
         {
              context.ExecuteCommand("ParseXML", inputXml);
         }
              
    }
