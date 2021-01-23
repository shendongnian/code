     protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable ) GridView1.DataSource;
                if (!dt.Columns.Contains("COLLUMN_YOU_WANNA_HIDE")) return;
                int j = dt.Columns.IndexOf("COLLUMN_YOU_WANNA_HIDE");
                e.Row.Cells[j].Visible = false;
                e.Row.Cells[j].Width = 0;
            }
            catch (Exception)
            {
            
            }
           
        }
