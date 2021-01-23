    public SomeControlToSave ActiveControl
    {
        get
        {
            if (tabControl.TabPages.Count == 0)
                return null;
            return tabControl.SelectedTab.Controls.OfType<SomeControlToSave>().FirstOrDefault();
        }
    }
