    public partial class TestPage1 : Page
    {
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (!IsPostBack)
    		{
    			ViewState["Data"] = MyUser.GetUsers();
    			ViewState["SortExpression"] = "Name";
    			DisplayData("Name", SortDirection.Ascending);
    		}
    	}
    
    	private void DisplayData(string sortExpression, SortDirection sortDirection)
    	{
    		Func<MyUser, object> f;
    		if (sortExpression == "Name") f = u => u.Name;
    		else f = u => u.BirthDate;
    
    		if (sortDirection == SortDirection.Ascending)
    		{
    			dgvView.DataSource = ((IEnumerable<MyUser>)ViewState["Data"]).OrderBy(f).ToList();
    		}
    		else
    		{
    			dgvView.DataSource = ((IEnumerable<MyUser>)ViewState["Data"]).OrderByDescending(f).ToList();
    		}
    
    		dgvView.DataBind();
    	}
    
    	protected void DgvViewPageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		dgvView.PageIndex = e.NewPageIndex;
    
    		string sortExpression = ViewState["SortExpression"].ToString();
    		DisplayData(sortExpression, GetDefaultSortDirection(sortExpression));
    	}
    
    	protected void OnSort(object sender, GridViewSortEventArgs e)
    	{
    		ViewState["SortExpression"] = e.SortExpression;
    		ViewState[e.SortExpression] = GetReverseSortDirection(e.SortExpression);
    		DisplayData(e.SortExpression, (SortDirection)ViewState[e.SortExpression]);
    	}
    
    	private SortDirection GetDefaultSortDirection(string sortExpression)
    	{
    		if (ViewState[sortExpression] == null)
    		{
    			ViewState[sortExpression] = SortDirection.Ascending;
    		}
    
    		return (SortDirection)ViewState[sortExpression];
    	}
    
    	private SortDirection GetReverseSortDirection(string sortExpression)
    	{
    		if (ViewState[sortExpression] == null)
    		{
    			ViewState[sortExpression] = SortDirection.Descending;
    		}
    		else
    		{
    			ViewState[sortExpression] = (SortDirection) ViewState[sortExpression] == SortDirection.Descending ? SortDirection.Ascending : SortDirection.Descending;
    		}
    
    		return (SortDirection)ViewState[sortExpression];
    	}
    }
