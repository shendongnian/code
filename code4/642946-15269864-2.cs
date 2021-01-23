    public void BindGrid()
            {
                DataTable db = new DataTable();
                db.Columns.Add("col1");
                db.Columns.Add("col2");
                db.Columns.Add("col3");
                db.Rows.Add("1", "2", "3");
                db.Rows.Add("1", "2", "3");
                db.Rows.Add("1", "2", "3");
    
                
                lvwTest.DataSource = db;
                lvwTest.DataBind();
            }
