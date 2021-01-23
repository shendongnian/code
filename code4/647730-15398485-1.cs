    public static void SetSelectedAllItems(this ListBox ctl)
    {
        ctl.BeginUpdate();
    
        for (int i = 0; i < ctl.Items.Count; i++)
        {
            ctl.SetSelected(i, true);
        }
        ctl.EndUpdate();
    }
