        foreach (Control item in PlaceHolder1.Controls)
        {
            if(item.GetType()== typeof(Button))
            {
                Button btn = (Button)item;
                btn.Click += new EventHandler(FunctionName);
            }
        }
    protected void FunctionName(object sender, EventArgs e)
    {
        //You code here to change colors
        Response.Write("Hello World");
    }
