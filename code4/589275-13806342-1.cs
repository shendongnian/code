        foreach (Control item in PlaceHolder1.Controls)
        {
            if(item.GetType().ToString() == "System.Web.UI.WebControls.Button")
            {
                Button btn = (Button)item;
                btn.Click += new EventHandler(Function);
            }
        }
    protected void Function(object sender, EventArgs e)
    {
        //You code here to change colors
        Response.Write("Hello World");
    }
