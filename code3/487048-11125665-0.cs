    // Initialisation.
    DataConnectionDialog dcd = new DataConnectionDialog();
    DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
    dcs.LoadConfiguration(dcd);
    // Edit existing connection string.
    if (!String.IsNullOrEmpty(strExistingConn))    
        dcd.ConnectionString = strExistingConn;
    // Launch Microsoft's SqlConnection dialog.
    string strSqlFinConn = String.Empty;
    if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
    {
        // Load tables as test.
        using (SqlConnection connection = new SqlConnection(dcd.ConnectionString))
            connection.Open();
    }
    dcs.SaveConfiguration(dcd);
    return dcd.ConnectionString;
