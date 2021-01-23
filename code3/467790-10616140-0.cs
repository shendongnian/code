    if(!Page.IsPostBack)
    {
    using (var conn = new SqlConnection(Properties.Settings.Default.DBConnectionString))
                {
                    conn.Open();
    
                    SqlDataAdapter daTags
                    = new SqlDataAdapter("Select * From Tag", conn);
    
                    DataSet dsTags = new DataSet("TagCloud");
    
                    daTags.FillSchema(dsTags, SchemaType.Source, "Tag");
                    daTags.Fill(dsTags, "Tag");
    
                    daTags.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    daTags.Fill(dsTags, "Tag");
    
                    DataTable tblTag;
                    tblTag = dsTags.Tables["Tag"];
    
                    dplTags.DataSource = dsTags;
                    dplTags.DataMember = "Tag"; 
                    dplTags.DataValueField = "TagID"; //Value Member
                    dplTags.DataTextField = "Value"; // Display Member
                    dplTags.DataBind();
                }
    }
