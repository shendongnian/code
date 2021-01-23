    public static int Save(Location location) {
      if ((location == null) || (location.Text == Location.NEW_LOCATION)) {
        return 0;
      }
      location.Result = 0;
      using (SQLiteConnection con = GetConnection) {
        try {
          con.Open();
          using (SQLiteTransaction txn = con.BeginTransaction()) {
            if (!String.IsNullOrEmpty(location.Text) && (location.Text != Location.NEW_LOCATION) && location.HasChanged) {
              string description = (location.Description != Location.NEW_LOCATION) ? location.Description : null;
              using (SQLiteCommand cmd = new SQLiteCommand(null, con)) {
                cmd.CommandText = Location.SQL_UPDATE;
                cmd.Parameters.AddWithValue(Location.AT_ID, location.ID);
                cmd.Parameters.AddWithValue(Location.AT_NUSE, location.InUse);
                cmd.Parameters.AddWithValue(Location.AT_TEXT, location.Text);
                if (location.Text == location.Description) {
                  cmd.Parameters.AddWithValue(Location.AT_DESC, DBNull.Value);
                } else {
                  cmd.Parameters.AddWithValue(Location.AT_DESC, location.Description);
                }
                location.Result = cmd.ExecuteNonQuery();
                location.HasChanged = false;
              }
            }
            foreach (var tank in location.Tanks) {
              tank.LocationID = location.ID;
              location.Result += Save(tank, con);
            }
            txn.Commit();
          }
          if (0 < location.Result) {
            dataSet.Tables.Remove(Location.TABLENAME);
            DataTable locationTable = new DataTable(Location.TABLENAME);
            using (SQLiteCommand cmd = new SQLiteCommand(Location.SQL_SELECT, con)) {
              locationTable.Load(cmd.ExecuteReader());
            }
            dataSet.Tables.Add(locationTable);
          }
        } catch (SQLiteException err) {
          location.Result = -1;
          LogError("Save(Location)", err);
        } finally {
          con.Close();
        }
      }
      return location.Result;
    }
