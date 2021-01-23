    if (lstNeeds.SelectedItem != null)
    {
        List<Int32> selIdx = lstNeeds.SelectedIndices.Cast<Int32>().ToList();
        selIdx.Sort();  //necessary?
        for (Int32 idx = selIdx.Count - 1; i >= 0; i--)
        {
            lstNeeds.Items.RemoveAt(selIdx[i]);
        }
    }
