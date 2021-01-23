    public void btn_Click(object sender, EventArgs e)
    {
        var b = sender as Button;
        
        if (b != null)
        {
            var name = b.Name;
            // do something with name
        }
    }
