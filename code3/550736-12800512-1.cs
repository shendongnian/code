    ArrayList Sorting = new ArrayList(); 
    foreach (var o in listBox1.Items) {
        Sorting.Add(o);
    } 
    Sorting.Sort(); 
    listBox1.Items.Clear();
    foreach (var o in Sorting) {
        listBox1.Items.Add(o); 
    }
