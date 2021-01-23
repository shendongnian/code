    btnInsertMode_Click(object sender, EventArgs e)
    {
    listview.Items.Clear();
    listview.SelectedIndex = 0;
    gridView.SelectedIndex = -1;
    listview.InsertItemPosition = InsertItemPosition.FirstItem;
    }
    btnUpdateMode_Click(object sender, EventArgs e)
    {
    listview.EditIndex = 0;
    }
