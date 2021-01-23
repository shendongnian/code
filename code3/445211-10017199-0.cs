    listView1.View=View.Details;
    listView1.Columns.Add("Name");
    listView1.Columns.Add("Number");
    string[] names= { "Abraham", "Buster", "Charlie" };
    int[] numbers= { 1018001, 1027400, 1028405 };
    for(int i=0; i<names.Length; i++)
    {
        listView1.Items.Add(
            new ListViewItem(new string[] {
            names[i], numbers[i].ToString() }));                
    }
