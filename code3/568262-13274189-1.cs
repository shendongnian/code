    private static int Save(Tank tank, SQLiteConnection con) {
      if ((tank == null) || (tank.Text == Location.NEW_TANK)) {
        return 0;
      }
      if (tank.LocationID < 0) {
        throw ExceptionFor("Location");
      }
      tank.Result = 0;
      if (!String.IsNullOrEmpty(tank.Text) && (tank.Text != Tank.NEW_TANK) && tank.HasChanged) {
        object description = (tank.Description != tank.Text) ? tank.Description : null;
        using (SQLiteCommand cmd = new SQLiteCommand(Tank.SQL_UPDATE, con)) {
          cmd.Parameters.AddWithValue(Tank.AT_ID, tank.ID);
          cmd.Parameters.AddWithValue(Tank.AT_LOC, tank.LocationID);
          cmd.Parameters.AddWithValue(Tank.AT_NUSE, tank.InUse);
          cmd.Parameters.AddWithValue(Tank.AT_TEXT, tank.Text);
          cmd.Parameters.AddWithValue(Tank.AT_DESC, description);
          try {
            tank.Result = cmd.ExecuteNonQuery();
          } catch (SQLiteException err) {
            tank.Result = -1;
            LogError("Save(Tank)", err);
          }
        }
      }
      if (0 < tank.Result) {
        tank.HasChanged = false;
        dataSet.Tables.Remove(Tank.TABLENAME);
        DataTable tanksTable = new DataTable(Tank.TABLENAME);
        using (SQLiteCommand cmd = new SQLiteCommand(Tank.SQL_SELECT, con)) {
          tanksTable.Load(cmd.ExecuteReader());
        }
        dataSet.Tables.Add(tanksTable);
        tank.Feeding.TankID = tank.ID;
        tank.Cleaning.TankID = tank.ID;
        tank.Filters.TankID = tank.ID;
      }
      tank.Result += Save(tank.Feeding, con);
      tank.Result += Save(tank.Cleaning, con);
      tank.Result += Save(tank.Filters, con);
      return tank.Result;
    }
