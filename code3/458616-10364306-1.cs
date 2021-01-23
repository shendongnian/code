    protected void DoDataBinding()
    {
        MyDataAccessClass dataAccess = new MyDataAccessClass();
        List<string> cats = dataAccess.GetCategories();
        cmb.Items.Clear();
        foreach (string cat in cats)
            cmb.Items.Add(cat);
    }
