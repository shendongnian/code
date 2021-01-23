    listBox1.BeginUpdate();
    listBox2.BeginUpdate();
    listBox3.BeginUpdate();
    listBox4.BeginUpdate();
    
    for (int n = 0; n < 7500; n++)
    {
        listBox1.Items.Add(itemList[n, 0].ToString());
        listBox2.Items.Add(itemList[n, 1].ToString());
        listBox3.Items.Add(itemList[n, 2].ToString());
        listBox4.Items.Add(itemList[n, 3].ToString());
    }
    
    
    listBox1.EndUpdate();
    listBox2.EndUpdate();
    listBox3.EndUpdate();
    listBox4.EndUpdate();
