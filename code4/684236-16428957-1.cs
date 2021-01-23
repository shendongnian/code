    private void Form1_Load(object sender, EventArgs e)
    {
        foreach (DataIWannaVisualize dataObject in dataList)
        {
            ListViewItem item = new ListViewItem();
            // TODO: Fill the item with the desired data.
            listView1.Items.Add(item);
        }
    }
