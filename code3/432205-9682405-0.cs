    private void cbnama_Click(object sender, EventArgs e)
    {
        var list = mDatabase.Viewpengujian()
    		.SelectMany(i => i)
    		.Distinct();
    
        cbnama.Items.Clear();
        foreach (var item in list)
        {
    		cbnama.Items.Add(item);
        }
    }
