    private void UpdateDB()
    {
        using (SqlConnection conn = new SqlConnection(SQLString.ConnStr))	// All new connection
        {
            try
            {
                dataAdapter.SelectCommand = new SqlCommand(SQLString.QryStr, conn);
                cmd.DataAdapter = dataAdapter;
                changeSet = dataSet.GetChanges();
                if (changeSet != null)
                {
                    dataAdapter.Update(changeSet, "tstRegion");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
