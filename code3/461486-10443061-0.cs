    DateTime tempDs = new DateTime();
                foreach (string str in dates)
                {
    
                    if (DateTime.TryParse(str, out tempDs))
                    {
                        Console.WriteLine("Found Date");
                    }
                }
