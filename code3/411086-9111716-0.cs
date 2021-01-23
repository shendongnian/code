    FileHelperAsyncEngine engine = new FileHelperAsyncEngine(typeof(Customer)); 
    engine.BeginReadFile("TestIn.txt"); 
    int recordCount = 0;
    foreach (Customer cust in engine)
    {    
        // your code here 
        Console.WriteLine(cust.Name);
        recordCount++;
        if (recordCount > 100)
            break; // stop processing 
    }
 
    engine.Close(); 
