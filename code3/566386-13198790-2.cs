    protected void grdBins_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
           int rec_id = int.Parse(grdBins.DataKeys[e.RowIndex].Value);
           using (SqlConnection conn = new SqlConnection(connectionString)){
                conn.Open();
                string cmdText = @"delete from t_run_schedule_lots
                                   where rec_id = @id";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn)){
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", rec_id);
                    cmd.ExecuteNonQuery();
                }
           }
           grd.EditIndex = -1;
           fill_grid();
           grdBins.DataBind(); 
    }
