    protected void Page_Load(object sender, EventArgs e)
    {
         Exception ex = Server.GetLastError();
         lblError.Text= ex.Message;
         Server.ClearError();
    }
