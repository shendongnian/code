    string[] line = textBox1.Lines; // get all the lines of text from Multiline Textbox
    int i = 0; // index for the array above
    foreach (ListViewItem itm in listView1.Items) // Iterate on each Item of the ListView
    {
       itm.SubItems.Add(line[i++]); // Add the line from your textbox to each ListViewItem using the SubItem
    }
