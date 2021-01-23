        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
               PopulateGridView();     
            }
            else
            {
               dt = (DataTable)Session["YourDatatable"]; //retrieve it from session
               sampleGridView.DataSource = dt;
               sampleGridView.DataBind();
            }
        }
        private void PopulateGridView()
        {
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Desgnation", typeof(string));
            dt.Columns.Add("City", typeof(string));
            for (int i = 0; i < src.GetLength(0); i++)
            {
                dt.Rows.Add(src[i, 0], src[i, 1], src[i, 2]);
            }
            sampleGridView.DataSource = dt;
            sampleGridView.DataBind();
            Session["YourDatatable"] = dt; //Store it for later
    
        }
