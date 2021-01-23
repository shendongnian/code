    protected void Button1_Click(object sender, EventArgs e)
    {
        HelperFunction(list => list.OrderBy(x => x));
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        HelperFunction(list => list.OrderByDescending(x => x));
    }
    
    private void HelperFunction(Func<IEnumerable<string>, <IEnumerable<string>> listOrderer)
    {
        var list = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text };
    
        var orderedList = listOrderer(list).ToArray();
    
        // rest of code
    }
