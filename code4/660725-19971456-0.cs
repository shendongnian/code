    protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 objws = new WebService1();
            Label1.Text = objws.HelloWorld(null);
        }
