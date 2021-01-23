    protected void ibtnClearFilterTown_Click(object sender, EventArgs e)
    {
       RgClientList.MasterTableView.GetColumnSafe("TownCity").CurrentFilterFunction = GridKnownFunction.NoFilter;
       RgClientList.MasterTableView.GetColumnSafe("TownCity").CurrentFilterValue = String.Empty;
       RgClientList.Rebind();
    }
