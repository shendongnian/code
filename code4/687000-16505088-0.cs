    protected void Page_Load(object sender, EventArgs e)
    {
    	if(!Page.IsPostBack){ // add this line 
    		SqlConnection con = new SqlConnection(str);
    		string com = "Select * from Plant";
    		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    		DataTable dt = new DataTable();
    		adpt.Fill(dt);
    		drop.DataSource = dt;
    		drop.DataBind();
    		drop.DataTextField = "PlantID";
    		drop.DataValueField = "PlantID";
    		drop.DataBind();
    	}
    }
