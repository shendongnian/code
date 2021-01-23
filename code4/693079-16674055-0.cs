    protected void Page_Load(object sender, EventArgs e)
            {
                GridView gv = new GridView();
                
                    gv.DataSource = Datatable();
                    gv.DataBind();
                    gv.Visible = true;
                    MyForm.Controls.Add(gv);
                
            }
            private DataTable Datatable()
        {
            DataTable datatable = new DataTable();
    
            datatable.Columns.Add("VenLogo", typeof(string));
            datatable.Columns.Add("VenName", typeof(string));
            datatable.Columns.Add("VenWeb", typeof(string));
    
            AddNewRow("Logo URL", "google", "http://google.com", datatable);
            AddNewRow("Logo URL", "facebook", "http://facebook.com", datatable);
    
            return datatable; 
        }
    
        private void AddNewRow(string id, string website, string url, DataTable table)
        {
            table.Rows.Add(id, website, url);
        }
    
    
        private string GetURL(string website, string url)
        {
            return "<a href=\"" + url + "\">" + website + "</a>";
        }  
