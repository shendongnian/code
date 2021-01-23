    private static int Save(Task task, SQLiteConnection con) {
      if (task.TankID < 0) {
        throw ExceptionFor("Tank");
      }
      //task.Date.TaskID = task.ID;
      task.Result = 0;
      task.DateResult = 0;
      if (!String.IsNullOrEmpty(task.Text)) {
        if (task.HasChanged || task.DateHasChanged) {
          using (SQLiteCommand cmd = new SQLiteCommand(Task.SQL_UPDATE, con)) {
            cmd.Parameters.AddWithValue(Task.AT_ID, task.ID);
            cmd.Parameters.AddWithValue(Task.AT_TANK, task.TankID);
            cmd.Parameters.AddWithValue(Task.AT_NUSE, task.InUse);
            cmd.Parameters.AddWithValue(Task.AT_TEXT, task.Text);
            cmd.Parameters.AddWithValue(Task.AT_LASTID, task.DateID);
            cmd.Parameters.AddWithValue(Task.AT_NUMBER, task.Number);
            cmd.Parameters.AddWithValue(Task.AT_UNIT, task.Units);
            if (task.Text == task.Description) {
              cmd.Parameters.AddWithValue(Task.AT_DESC, DBNull.Value);
            } else {
              cmd.Parameters.AddWithValue(Task.AT_DESC, task.Description);
            }
            try {
              if (task.HasChanged) {
                task.Result = cmd.ExecuteNonQuery();
              }
              if (0 < Save(task.GetDate(), con)) {
                if (task.DateHasChanged) {
                  task.Date(GetLastInsertRowID(con), task.ID, DateTime.Today);
                  cmd.Parameters[Task.AT_LASTID].Value = task.DateID;
                  task.Result += cmd.ExecuteNonQuery();
                }
              }
            } catch (SQLiteException err) {
              task.Result = -1;
              LogError("Save(Task)", err);
            }
          }
          if (0 < task.Result) {
            dataSet.Tables.Remove(Task.TABLENAME);
            DataTable tasksTable = new DataTable(Task.TABLENAME);
            using (SQLiteCommand cmd = new SQLiteCommand(Task.SQL_SELECT, con)) {
              tasksTable.Load(cmd.ExecuteReader());
            }
            dataSet.Tables.Add(tasksTable);
          }
          task.HasChanged = false;
        }
      }
      return task.Result;
    }
