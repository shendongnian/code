    public void Tooltip(ListControl lc)
    {
        for (int d = 0; d < lc.Items.Count; d++)
        {
            lc.Items[d].Attributes.Add("title", lc.Items[d].Text);
        }
    }
