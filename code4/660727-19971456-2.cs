     protected void Button1_Click(object sender, EventArgs e)
        {
            WebService1 objws = new WebService1();
            objws.voidMethod(5);
            Label1.Text = objws.HelloWorld(5);
        }
