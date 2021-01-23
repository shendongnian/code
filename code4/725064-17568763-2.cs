        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connection;        
        command.CommandText = "Select tblAssets.AssetID, tblAssets.Domain, tsysOS.OSname, tblAssets.SP,"
        + " tblAssets.Memory, tblAssets.Processor, tblAssetCustom.Manufacturer, tblAssetCustom.Model"
        + " FROM tblAssets"
        + " INNER JOIN tblAssetsCustom ON tblAssets.AssetID = tblAssetCustom.AssetID "
        + " INNER JOIN tsysOS ON tblAssets.OScode = tsysOS.OScode "
        + " WHERE tblAssets.AssetName = @AssetName";
        connection.Open();
        command.Parameters.Add("@AssetName",SqlDbType.NVarchar).Value = Aname;      
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {      
              TextBoxAssetID.Text = reader["AssetID"].ToString();
              TextBoxDomain.Text = reader["Domain"].ToString();
              TextBoxOS.Text = reader["OSname"].ToString();
              TextBoxSP.Text = reader["SP"].ToString();
              TextBoxMemory.Text = reader["Memory"].ToString();
              TextBoxProcessor.Text = reader["Processor"].ToString();
              TextBoxManufacturer.Text = reader["Manufacturer"].ToString();
              TextBoxModel.Text = reader["Model"].ToString();
            }
        
        ////// Rest of code goes from Here ...
