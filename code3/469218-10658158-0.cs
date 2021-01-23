    private void srchBTN_Click(object sender, EventArgs e)
    {
       string conString = Properties.Settings.Default.CurricularChangeTrackerConnectionString;
       DataTable table = new DataTable();
       using (SqlCeConnection conn = new SqlCeConnection(conString))
       {
         string queryString = ("SELECT * FROM SecondaryEducation WHERE ProgramCode='" + PrgmCde.SelectedValue + "'");
       try
       {
          conn.Open();
          
          using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(queryString, conn))
          {
              
              adapter.Fill(table);
              dataGridView1.DataSource = table;
              adapter.Dispose();
          }
          conn.Close();
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message);
       }
      }
    }
