    private void EditButton_Click(object sender, EventArgs e)
    {
        string content = clbSummary.SelectedItem.ToString();
        string newValue = Interaction.InputBox("Provide new value", "New Value", content, -1, -1);
        int selectedIndex = clbSummary.SelectedIndex;
        clbSummary.Items.RemoveAt(selectedIndex);
        clbSummary.Items.Insert(selectedIndex, newValue);
    }
