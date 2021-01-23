    private void BindData()
        {
            string query = "";
            if (txtSearch.Text != "" &&  txtSearch.Text != string.Empty) {
                query = "select * from Ressources where data like'%" + txtSearch.Text + "%'";                 
            } else {
                 query = "select * from Ressources";
            }
            
            SqlCommand cmd = new SqlCommand(query);
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();
        }
