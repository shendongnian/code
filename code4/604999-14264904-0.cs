       private void Page_Load(object sender, EventArgs e)
       {
          if(IsPostBack) // If postback, then bind GridView with previous search result
          {
             dgvSearchResults.DataSource = Session["dgvSearchResultsData"];
             dgvSearchResults.DataBind();
          }
       }
    
    
       private void generateSearchGrid(DataTable dt)
       {
           // ...
           Session["dgvSearchResultsData"] = dt; // Save result into session
           dgvSearchResults.DataSource = dt;
           // ...
       }
