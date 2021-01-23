    IExcelRepository<Client> repo = new ExcelRepository<Client>(@"C:\file.xls");
    
    var largeClients = from c in repo.Worksheet
    
                      where c.Employees > 200
    
                      select c;
    
    foreach (Client client in largeClients)
    {
       Console.WriteLine(client.ClientName);
    }
