        int lines = 0;
        try 
        {
             using (StreamReader sr = new StreamReader("Encoding.txt")) 
            {
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    lines++;   
                }
            }
        }
        catch (Exception e) 
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
