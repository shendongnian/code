    using (TransactionScope transScope = new TransactionScope())
    {
       try
       {
          string myConnStringLocal = "User Id=***;Password=****;Host=" + globalSettings.settingLocalIP + ";Database=" + globalSettings.settingLocalDB;
          using (MySqlConnection connectionLocal = new MySqlConnection(myConnStringLocal))
          {
             connectionLocal.Open();
          }
          string myConnStringCentral = "User Id=***;Password=*****;Host=" + globalSettings.settingCentralIP + ";Database=" + globalSettings.settingCentralDB;
          using (MySqlConnection connectionCentral = new MySqlConnection(myConnStringCentral))
          {
             connectionCentral.Open();
          }
          string myConnStringCentralCopy = "User Id=*****;Password=*****;Host=" + globalSettings.settingCentralCopyIP + ";Database=" + globalSettings.settingCentralCopyDB;
          using (MySqlConnection connectionCentralCopy = new MySqlConnection(myConnStringCentralCopy))
          {
             connectionCentralCopy.Open();
          }
          transScope.Complete();
          Console.WriteLine("Transaction is completed");
       }
       catch (Exception)
       {
          Console.WriteLine("Transaction is rolled back");
       }
    }
