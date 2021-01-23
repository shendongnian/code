    //Use the below code to cancel the Grouping for particular group based on the keu
    void Table_GroupCollapsing(object sender, GroupCollapsingEventArgs args)
    {
        if (args.Group.Key.Equals(1))
            args.Cancel = true;
    }
