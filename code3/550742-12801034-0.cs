    listBox1.Items.Add(3);
    listBox1.Items.Add(1);
    listBox1.Items.Add(2);
    
    ArrayList sort = new ArrayList();
    foreach (object item in listBox1.Items)
    {
        sort.Add(item);
    }
    sort.Sort();
    listBox1.Items.Clear();
    foreach (int item in sort)
    {
        listBox1.Items.Add(item);
    }
