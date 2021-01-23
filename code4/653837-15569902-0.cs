    private void clearRedundantSubscriptions()
    {
        string sql;
        // Check if there are any entries in customerlist table which point to non-existing lists
		var list = new List<int>();
        try
        {
			if (DbConnection.ceConnection.State == ConnectionState.Closed)
				DbConnection.ceConnection.Open();
				
            sql = "select distinct cl.listid from customerlist cl inner join list l on cl.listid != l.listid";
			
            SqlCeCommand cmdGetDisusedLists = new SqlCeCommand(sql, DbConnection.ceConnection);
            SqlCeDataReader reader = cmdGetDisusedLists.ExecuteReader();
            while (reader.Read())
            {
				list.Add(reader.GetInt32(0));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error cleaning up list entries." + ex.Message);
            throw;
        }
		finally
		{
			DbConnection.closeConnection();
		}
		
		foreach(var id in list)
		{
			DeleteList(id,false);
		
		}
        return;
    }
    public static bool DeleteList(int id, bool display)
    {
        string sql;
        string title = "";
        bool ranOk = false;
        try
        {
            sql = "select ShortDesc from list where listid=" + id;
            DbFunctions.runSQL(sql, out title);
			
			
            sql = "delete from list where ListId=" + id;
			SqlCeCommand cmdDelList = new SqlCeCommand(sql, DbConnection.ceConnection);
            cmdDelList.ExecuteNonQuery();
            sql = "delete from customerlist where listid=" + id;
            SqlCeCommand cmdDelEntries = new SqlCeCommand(sql, DbConnection.ceConnection);
            cmdDelEntries.ExecuteNonQuery();
            if (display)
                General.doneWork(title + " list deleted.");
            ranOk = true;
        }
        catch (Exception ex)
        {
            if (display)
                MessageBox.Show("Unable to delete list. " + ex.Message);
        }
        finally
        {
                DbConnection.closeConnection();
        }
        return ranOk;
    }
    public static void closeConnection()
    {
        if (_sqlCeConnection != null)
            _sqlCeConnection.Close();
    }
