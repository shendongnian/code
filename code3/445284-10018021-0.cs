    void SomeMethod()
    {
        BlockingCollection<int> col = new BlockingCollection<int>();
        
        Task.StartNew( () => { 
            
            for (int j = 0; j < 50; j++)
            {
                col.Add(j);
            }
            
            col.CompleteAdding(); 
         
         });
        
        foreach (var item in col.GetConsumingEnumerable())
        {
           //item is removed from the collection here, do something
           Console.WriteLine(item);
        }
    }
