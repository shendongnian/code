    private void buttonDelete_Click(object sender, EventArgs e)
    {
        if (yourListView.SelectedItems.Any())
        {
             //selected data is of custom type MyData
             var selected = yourListView.SelectedItems.First();
        }
    }
