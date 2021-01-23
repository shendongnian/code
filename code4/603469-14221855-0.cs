    ArrayList arList = new ArrayList(); 
    foreach (object obj in listBox1.Items)
    {
        arList.Add(obj);
    } 
    arList.Sort(); 
    listBox2.Items.Clear();
    foreach(object obj in arList)
    {
        listBox2.Items.Add(obj); 
    }
