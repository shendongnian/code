    protected void Button_Click(object sender, EventArgs e)
    {
        var list = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
        var orderedlist = (sender as Button).Name == "Button_Desc" // or whatever name it is
                          ? list.OrderByDescending(x => (x)).ToArray()
                          : list.OrderBy(x => (x)).ToArray();
        .............
    }
 
