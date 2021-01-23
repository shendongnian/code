    public static void Main()
    {
        string  d = Directory.GetCurrentDirectory();
        string[] directorys = Directory.GetDirectories(d);
        foreach (var item in directorys )
        {
            Debug.Print(item);
        }
        try
        {
            using (StreamWriter sw = new StreamWriter("\\WINFS\\temp.txt"))
            {
                sw.WriteLine("Good Evening");
                sw.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
