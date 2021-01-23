    try
    {
        Directory.CreateDirectory(Environment.SpecialFolder.LocalApplicationData + "\\MyService");
    }
    catch (Exception ex)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\MyServicelog.txt",true);
        file.WriteLine(ex.Message);
        file.Close();
    }
