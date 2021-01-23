    listView1.CheckBoxes = true;
    listView1.View = View.Details;
    //Set the column headers and populate the columns.
    listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
    ColumnHeader columnHeader1 = new ColumnHeader();
    columnHeader1.Text = "Title";
    columnHeader1.TextAlign = HorizontalAlignment.Left;
    columnHeader1.Width = 146;
    listView1.Columns.Add(columnHeader1);
    listView1.BeginUpdate();
    foreach (ArrayList post in posts)
    {
        string[] postArray = new string[] { post[0].ToString() };
        ListViewItem listItem = new ListViewItem(postArray);
        listItem.Tag = post;
        listView1.Items.Add(listItem);
    }
    //Call EndUpdate when you finish adding items to the ListView.
    listView1.EndUpdate();
