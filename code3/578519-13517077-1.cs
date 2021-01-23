    private void DeleteButton_Click(object sender, EventArgs e)
    {
        for (int i = clbSummary.CheckedIndices.Count - 1; i >= 0; --i)
        {
            clbSummary.Items.RemoveAt(clbSummary.CheckedIndices[i]);
        }
    }
