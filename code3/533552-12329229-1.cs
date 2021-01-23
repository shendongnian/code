    if (ListBox1.Items.Count == ListBox2.Items.Count)
    {
        string[] listbox1arr = ListBox1.Items.OfType<string>().ToArray();
        string[] listbox2arr = ListBox2.Items.OfType<string>().ToArray();
        bool flag = listbox1arr.Intersect(listbox2arr).Count() > 0;
        MessageBox.Show(flag : "Items are not same" : "Items are same");
    }
