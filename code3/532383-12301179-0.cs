    public void SetList(List<bool> checkmarks)
    {
        for (int i = 0; i < checkmarks.Count; ++i)
        {
            checkedListBox1.SetItemChecked(i, checkmarks[i]);
        }
    }
