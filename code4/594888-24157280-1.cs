    protected new void Page_Load(object sender, EventArgs e)
    {
       var exp = this.RadGrid.MasterTableView.SortExpressions; 
       if (exp.Count == 0)
       {
          this.SortGrid(new GridSortExpression { FieldName = "DefectId", SortOrder = GridSortOrder.Ascending});
       }
       else
       {
          this.SortGrid(exp[0]);
       }
    }
	protected void SortCommand(object sender, GridSortCommandEventArgs e)
	{
		this.SortGrid(new GridSortExpression { FieldName = e.SortExpression, SortOrder = e.NewSortOrder });
	}
    private void SortGrid(GridSortExpression e)
    {
    	IOrderedEnumerable<Defects> bindingList = null;
    	var defects = DataAccessLayer.GetLoadedSet<Defects>().ToList();
    	if (Defects.ColumnMapper.ContainsKey(e.FieldName))
    	{
            var prop = Defects.ColumnMapper[e.FieldName];
    	    switch (e.SortOrder)
    	    {
    		case GridSortOrder.Ascending:
    			bindingList = defects.OrderBy(src => prop.GetValue(src, null));
    			break;
    		case GridSortOrder.Descending:
    			bindingList = defects.OrderByDescending(src => prop.GetValue(src, null));
    			break;
    		case GridSortOrder.None:
    			bindingList = defects.OrderBy(src => src.DefectId);
    			break;
    	    }
    	}
    	this.RadGrid.DataSource = bindingList;
    }
