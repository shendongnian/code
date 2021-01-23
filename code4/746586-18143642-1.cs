    private void loadDataByAll()
    {
     try
     {
         // lviewGuard.Items.Clear();
         con.ConnectionString = dbcon.getConnectionString();
         con.Open();
         String query = "SELECT guardid AS a, g_firstname AS b, g_midname AS c, g_lastname AS d, g_age AS e, g_gender AS f, g_address AS g, g_contactno AS h, g_licno AS i, g_lic_until AS j, g_assigned_client AS k, g_schedule_from AS l, g_schedule_to AS m, app_no AS n";
         query += " FROM guards";
         query += " WHERE resigned = '0' ORDER BY app_no DESC";
         OleDbCommand cmd = new OleDbCommand(query, con);
         cmd.ExecuteScalar();
         OleDbDataReader rdr = cmd.ExecuteReader();   
         List<obj> data = new List<obj>();
         while (rdr.Read())
         {
             data.Add( new obj 
             {
               a = rdr["a"],
               b = rdr["b"]
             });
          }               
          con.Close();
          this.Invoke(new Action(delegate { UpdateListview(data); }));
      }
      catch (Exception)
      {
          MessageBox.Show("MDB Database is not Present", "Microsoft Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          Application.ExitThread();
      }
}
    public void UpdateListview(List<obj> data)
    {
        lviewGuard.BeginUpdate();
        lviewGuard.Items.Clear();
        foreach(obj o in data)
        {
             ListViewItem lv = new ListViewItem(rdr["a"].ToString());
             lv.SubItems.Add(o.b.ToString());
             lv.SubItems.Add(o.c.ToString());
             lviewGuard.Items.Add(lv);
        }
        
        lviewGuard.EndUpdate();
    }
