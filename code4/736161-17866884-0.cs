    public string Write_txt(string textin, String output)
    {
        try
        {
            using (StreamReader sr = new StreamReader(textin))
            {
                String line = sr.ReadToEnd();
                output = line;
                return output;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            return null;
        }
    }
