     FileStream errorFileStream = new FileStream("Error.txt", FileMode.OpenOrCreate);
                StreamWriter errorStreamWriter = new StreamWriter(errorFileStream);
                Console.SetError(errorStreamWriter);
    
                string[] test = new string[2];
                test[0] = "Hello";
                test[1] = "World";
    
                try
                {
                    Console.WriteLine(test[2]);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
    
                Console.Error.Close();
