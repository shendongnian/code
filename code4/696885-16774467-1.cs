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
        using (SqlDataAdapter da = new SqlDataAdapter())
        {
            da.SelectCommand.CommandText = "SELECT Id,SectionTitle FROM SectionEnty";
            da.SelectCommand.Connection = new SqlConnection("your connection");
    
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
        using (SqlDataAdapter da = new SqlDataAdapter())
        {
            da.SelectCommand.CommandText = "SELECT Id,ClassTitle FROM ClassEntry WHERE SectionId = @SectionId";
            da.SelectCommand.Parameters.Add(new SqlParameter("@SectionId", sectiondropdown.SelectedValue));
            da.SelectCommand.Connection = new SqlConnection("your connection");
    
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
        using (SqlDataAdapter da = new SqlDataAdapter())
        {
            da.SelectCommand.CommandText = "SELECT Id,FullName FROM StudentInfo WHERE ClassId = @ClassId";
            da.SelectCommand.Parameters.Add(new SqlParameter("@ClassId", classdropdown.SelectedValue));
            da.SelectCommand.Connection = new SqlConnection("your connection");
    
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
