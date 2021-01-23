    // Honestly, this string  just helps me avoid typos when 
    // referencing the session variable
    string authorKey = "authors";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // If the session variable is empty, initialize an 
            // empty list as the datasource
            if (Session[authorKey] == null)
            {
                Session[authorKey] = new List<Author>();
            }
            BindList();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Grab the current list from the session and add the 
        // currently selected DropDown item to it.
        List<Author> authors = (List<Author>)Session[authorKey];
        authors.Add(new Author(DropDownList1.SelectedValue));
        BindList();
    }
    private void BindList()
    {
        ListView1.DataSource = (List<Author>)Session[authorKey];
        ListView1.DataBind();
    }
    // Basic author object, used for databinding
    private class Author
    {
        public String AuthorName { get; set; }
        public Author(string name)
        {
            AuthorName = name;
        }
    }
