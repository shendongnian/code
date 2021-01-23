    static void DirTest()
    {
        string dir = "Temp";
        int i = 0;
        try
        {
            for (i = 0; i < int.MaxValue; i++)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string file = Path.Combine(dir, "sample.txt");
                File.Create(file).Close();
                File.Delete(file);
                Directory.Delete(dir);
                System.Console.WriteLine("Finished i: " + i);
            }
        }
        catch
        {
            System.Console.WriteLine("Error on i: " + i);
            throw;
        }
    }
