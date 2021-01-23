    public string Write_txt(string textin)
    {
        try
        {
            using (StreamReader sr = new StreamReader(textin))
            {
                String line = sr.ReadToEnd();
                return line;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            return null;
        }
    }
