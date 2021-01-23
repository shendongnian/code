        protected void getNewsDetails()
        {
            DataTable dtNewsDetails = new DataTable();
            //retrieve data from database into the DataTable
            GridView1.DataSource = dtNewsDetails;
            GridView1.DataBind();
        }
    
