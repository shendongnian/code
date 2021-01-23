    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostback) {
            Timer1.Enabled = false;
            Label2.Text = "Panel refreshed at: " +
              DateTime.Now.ToLongTimeString(); // Checks if page reloads
        }
    }
