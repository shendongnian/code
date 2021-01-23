    listView1.Columns.Add("Column 1");
    listView1.Columns.Add("Column 2");
    string[] strArr = new string[4] { "uno", "dos", "twa", "quad" };
    foreach (string x in strArr)
    {
        ListViewItem lvi = listView1.Items.Add(x);
        lvi.SubItems.Add("Ciao, Baby!");
    }
