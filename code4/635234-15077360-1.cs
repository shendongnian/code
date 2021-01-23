    protected void Button_Click(object sender, EventArgs e)
    {
        var list = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
        var orderedlist = (sender as Button).AccessKey  == "Button1" // or whatever name it is
                          ? list.OrderByDescending(x => (x)).ToArray()
                          : list.OrderBy(x => (x)).ToArray();
        .............
    }
 
