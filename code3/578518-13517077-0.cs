    private void DeleteButton_Click(object sender, EventArgs e)
    {
        for(int i = clbSummary.SelectedIndices.Count - 1; i >= 0; --i)
        {
            clbSummary.Items.RemoveAt(clbSummary.SelectedIndices[i]);
        }
    }
