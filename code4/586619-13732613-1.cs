    private void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = clbSummary.CheckedIndices.Count - 1; i >= 0; --i)
        {
            object item = clbSummary.Items[clbSummary.CheckedIndices[i]];
            myList = myList.Remove(item);
            clbSummary.Items.RemoveAt(clbSummary.CheckedIndices[i]);
            
        }
    }
