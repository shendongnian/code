    try
    {
      SqlCeCommand cmd = objCon.CreateCommand();
      cmd.CommandText = tblQuery;
      object objcnt = cmd.ExecuteScalar();
      if ((objcnt != null) && (objcnt != DBNull.Value)) {
        validTable = Int32.Parse(objcnt.ToString());
      } else {
        MessageBox.Show("NULL returned from CreateCommand. Remove this line.");
      }
    }
    catch
