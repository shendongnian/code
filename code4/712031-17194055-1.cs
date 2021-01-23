    if (lstNeeds.SelectedItem != null)
    {
        List<Int32> selIdx = new List<Int32>();
        foreach (var item in lstNeeds.SelectedItems)
            selIdx.Add(lstNeeds.Items.IndexOf(item);
        selIdx.Sort();  //necessary?
        for (Int32 idx = selIdx.Count - 1; i >= 0; i--)
        {
            lstNeeds.Items.RemoveAt(selIdx[i]);
        }
    }
