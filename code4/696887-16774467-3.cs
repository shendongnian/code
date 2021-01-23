    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadClassDropdown();
        }
    }
    
    // set initial values
    private void LoadClassDropdown()
    {
        using (SqlDataAdapter da = new SqlDataAdapter("SELECT Id,SectionTitle FROM SectionEnty", "your connection string"))
        {    
            using (DataSet ds = new DataSet())
            {
                da.SelectCommand.Connection.Open();
                da.Fill(ds);
                da.SelectCommand.Connection.Close();
    
                classdropdown.DataSource = ds;
                classdropdown.DataValueField = "Id";
                classdropdown.DataTextField = "SectionTitle";
                classdropdown.DataBind();
            }
        }
    }
        
    protected void classdropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlDataAdapter da = new SqlDataAdapter("SELECT Id,ClassTitle FROM ClassEntry WHERE SectionId = @SectionId", "your connection string")
        {
            da.SelectCommand.Parameters.Add(new SqlParameter("@SectionId", sectiondropdown.SelectedValue));
    
            using (DataSet ds = new DataSet())
            {
                da.SelectCommand.Connection.Open();
                da.Fill(ds);
                da.SelectCommand.Connection.Close();
    
                sectiondropdown.DataSource = ds;
                sectiondropdown.DataValueField = "Id";
                sectiondropdown.DataTextField = "ClassTitle";
                sectiondropdown.DataBind();
            }
        }
    }
        
    protected void sectiondropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlDataAdapter da = new SqlDataAdapter("SELECT Id,FullName FROM StudentInfo WHERE ClassId = @ClassId", "your connection string"))
        {
            da.SelectCommand.Parameters.Add(new SqlParameter("@ClassId", classdropdown.SelectedValue));
    
            using (DataSet ds = new DataSet())
            {
                da.SelectCommand.Connection.Open();
                da.Fill(ds);
                da.SelectCommand.Connection.Close();
    
                studentnamedropdown.DataSource = ds;
                studentnamedropdown.DataValueField = "Id";
                studentnamedropdown.DataTextField = "FullName";
                studentnamedropdown.DataBind();
            }
        }
    }
