    private void button2_Click(object sender, EventArgs e)
    {
        List<string> names = new List<string>();
        for (int i = 0; i < salesmen.Length; i++)//var salesmen in salesmen)
        {
            if (salesmen[i] != null)
            {
                names.Add(salesmen[i].name); // changed from .Name to .name
            }
        }
        listBox1.Items.Add(names);
    }
