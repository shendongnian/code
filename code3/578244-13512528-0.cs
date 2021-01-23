    public static void StartPlugin()
    {
        using (LoginWindow login = new LoginWindow())
        {
           DialogResult result = login.ShowDialog();
           if (result == DialogResult.Ok)
           {
               Console.WriteLine("It works");
           }
        }
    }
