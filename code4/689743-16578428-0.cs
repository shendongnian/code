    protected void Page_Load(object sender, EventArgs e)
            {
                if(Page.IsPostBack == false)
                {
        
                SqlConnection connSel = new SqlConnection("Data Source = localhost;" + "Initial Catalog = project; Integrated Security = SSPI");
    
                connSel.Open();
        
                SqlDataAdapter adapSel;
        
                string mySQL = "Select * from Report";
        
                adapSel = new SqlDataAdapter(mySQL, connSel);
        
                DataSet dsSel = new DataSet();
                adapSel.Fill(dsSel);
                GWCase.DataSource = dsSel;
                GWCase.DataBind();
        
                connSel.Close();
        
            }
            }
