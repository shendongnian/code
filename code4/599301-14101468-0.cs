    public form2()
    {
        InitializeComponent();
        try
        {
            String _server_name;
            // set value of _server_name
            txtServer.Text = _server_name;
        }
        catch (Exception er) { System.Console.WriteLine("An error occurs :" + er.Message + " - " + er.StackTrace); }
    }
