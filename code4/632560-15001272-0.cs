    public static int ToInt(string number, string info)
    {
        try
        {
            // ...
        }
        catch(Exception e)
        {
            MessageBox.Show(info);
        }
    }
    // and usage
    string str1 = "123";
    int n = ToInt(str1, "Trying to parsing str1");
   
