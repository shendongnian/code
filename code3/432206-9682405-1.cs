    private void cbnama_Click(object sender, EventArgs e)
    {
        // this will give you an IEnumerable<string>
        var list = mDatabase.Viewpengujian()
    		.SelectMany(i => i)
    		.Distinct();
    
        cbnama.Items.Clear();
        // since now list is a IEnumerable<string> you can just loop through it
        foreach (var item in list)
        {
    		cbnama.Items.Add(item);
        }
    }
