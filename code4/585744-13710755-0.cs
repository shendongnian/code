    public async Task<bool> CheckConnection()
    {
        try
        {
            using (OleDbConnection db = new OleDbConnection(this.conString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "select 1 from sysibm.sysdummy1";
                cmd.Connection = db;
                db.Open();
                await cmd.ExecuteReaderAsync();
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
