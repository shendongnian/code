    private void selectContents_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        listBox1.Items.Add(selectContents.SelectedItem);
        Label1.Text = selectContents.SelectedItem;
    }
