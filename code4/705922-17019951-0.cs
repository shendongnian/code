    private List<Book> SelectedBooks
    {
    	get
    	{
    		return Session["SelectedBooks"] as List<Book>;
    	}
    	set
    	{
    		Session["SelectedBooks"] = value;
    	}
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{		
    		var selectedBooks = SelectedBooks;
    		if(selectedBooks == null)
    		{
    			// Populate the selected books first time
    			// SelectedBooks = ...
    		}
    		
    		BindGridview(SelectedBooks);
    	}
    }
    
    private void BindGridview(List<Book> bookList)
    {	
    	GridViewProducts.DataSource = bookList;
    	GridViewProducts.DataBind();
    }
    
    protected void GridViewProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {      
    	SelectedBooks.RemoveAt(e.RowIndex);			
    	BindGridview(SelectedBooks);
    }
