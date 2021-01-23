     private void BindGrid()
        {
            DataTable dt;
            if (Session["GridData"] == null)
            {
                dt = GetData();//From database or and other source
                Session["GridData"] = dt;
            }
            else
            {
                dt = (DataTable)Session["GridData"];
            }
            GridView.datasource = dt;
            GridView.Databind();
        }
        private void UpdataData(object sender, EventArgs e)
        {
            DataTable dt;
            if (Session["GridData"] != null)
            {
                dt = (DataTable)Session["GridData"];
            
            // Do whatever you want with dt (datatable);
            Session["GridData"] = dt;
            BindGrid();
           }
        }
