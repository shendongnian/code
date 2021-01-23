    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "btnRelease")
        {
            GridDataItem item = (GridDataItem)e.Item; 
            // Replace "TrxId" with the reference to the item containing your TrxId
            string TrxId = item["TrxId"].Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ZEUS"].ConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE [TransactsData] SET [IsReleased] = 1, [TimeReleased] = GETDATE() WHERE [TrxId] = @TrxId", con);
            command.Parameters.AddWithValue("@TrxId", TrxId);
            command.ExecuteNonQuery();
            con.Close();
        } 
    }
