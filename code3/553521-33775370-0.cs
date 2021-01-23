                    foreach (var item in repo1.RetrieveStatus())
                    {
                        Console.WriteLine(item.FilePath);
                        Console.WriteLine(item.State);
                    }
      
