    static DataClasses1DataContext dbDataClasses = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            Guid someGuid;
            if(Guid.TryParse("e8d82d5d", out someGuid))
            {
                 var accountList = from accounts in dbDataClasses.ACCOUNTs where accounts.AccountGUID= someGuid
                              select accounts;
    
                foreach (ACCOUNT temp in accountList)
                {
                     Console.WriteLine("Account Name: " + temp.Name + " Account GUID: " + temp.AccountGUID);
                }
            }
            else
            {
                //error handle
            }
    
        
       }
