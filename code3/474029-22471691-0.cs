            //// Retrieve the enumerator instance, and then retrieve the data sources.
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable dtDatabaseSources = instance.GetDataSources();
            //// Populate the data sources into DropDownList.            
            foreach (DataRow row in dtDatabaseSources.Rows)
                if (!string.IsNullOrWhiteSpace(row["InstanceName"].ToString()))
                    Model.DatabaseDataSourceNameList.Add(new ExportWizardChooseDestinationModel
                    {
                        DatabaseDataSourceListItem = row["ServerName"].ToString()
                            + "\\" + row["InstanceName"].ToString()
                    });
