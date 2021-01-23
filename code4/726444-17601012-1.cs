    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {
      if (GridView1.Rows[e.RowIndex].RowType == DataControlRowType.DataRow) {
        string index = GridView1.Rows[e.RowIndex].Cells[1].Text; //DwgRegID
        string sqlUpdate = "UPDATE dbo.Dwg_Register SET " +
          "Ref=@Ref, Dwg_Ref=@Dwg_Ref, Title=@Title, Dwg_Received_Date=@Dwg_Received_Date, " +
          "Rev=@Rev, Trade=@Trade, type1=@type1, Produced_Date=@Produced_Date, " +
          "Produced_By=@Produced_By, Submittal_Ref=@Submittal_Ref, Issued_To=@Issued_To, " +
          "Date_Issued=Date_Issued, Purpose=@Purpose, status1=@status1, Action_Date=@Action_Date " +
          "WHERE DwgRegID=N'" + index + "'";
        string sqlSelect = "SELECT DwgRegID, Ref, Dwg_Ref, Title, Dwg_Received_Date, Rev, Trade, type1, Produced_Date, Produced_By, Submittal_Ref, " +
          "Issued_To, Date_Issued, Purpose, status1, Action_Date " +
          "from dbo.Dwg_Register";
        var table = new DataTable();
        using (var cmd = new SqlCommand(sqlUpdate, new SqlConnection(m_sqlConn))) {
          cmd.Parameters.AddWithValue("@Ref", DbSafe(txtRef.Text));
          cmd.Parameters.AddWithValue("@Dwg_Ref", DbSafe(txtDwgRef.Text));
          cmd.Parameters.AddWithValue("@Title", DbSafe(txtTitle.Text));
          cmd.Parameters.AddWithValue("@Dwg_Received_Date", DbSafe(txtDwgReceivedDate.Text));
          cmd.Parameters.AddWithValue("@Rev", DbSafe(txtRev.Text));
          cmd.Parameters.AddWithValue("@Trade", DbSafe(ddlTrade.Text));
          cmd.Parameters.AddWithValue("@type1", DbSafe(ddlType.Text));
          cmd.Parameters.AddWithValue("@Produced_Date", DbSafe(txtProducedDate.Text));
          cmd.Parameters.AddWithValue("@Produced_By", DbSafe(ddlProducedBy.Text));
          cmd.Parameters.AddWithValue("@Submittal_Ref", DbSafe(txtSubmittalRef.Text));
          cmd.Parameters.AddWithValue("@Issued_To", DbSafe(ddlIssuedTo.Text));
          cmd.Parameters.AddWithValue("@Date_Issued", DbSafe(txtDateIssued.Text));
          cmd.Parameters.AddWithValue("@Purpose", DbSafe(ddlPurpose.Text));
          cmd.Parameters.AddWithValue("@status1", DbSafe(ddlStatus.Text));
          cmd.Parameters.AddWithValue("@Action_Date", DbSafe(txtActionDate.Text));
          //cmd.Parameters.Add(new SqlParameter("@DwgRegID", index));
          try {
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.CommandText = sqlSelect;
            cmd.Parameters.Clear();
            table.Load(cmd.ExecuteReader());
          } catch (SqlException err) {
            Response.Write(err.Message);
          } finally {
            cmd.Connection.Close();
          }
        }
        GridView1.DataSource = table;
        GridView1.DataBind();
        MultiView1.SetActiveView(ViewGrid);
        lblUpdate.Text = "Record updated sucessfully.";
      }
    }
