    private void Fill_DataGrid_ServiceName()
        {
            this.Cursor = Cursors.Wait;
            
            // create an instance
            DatabaseClass objDatabaseClass = new DatabaseClass(_connectionString);
            // if we are able to open and close the SQL Connection then proceed
            if (objDatabaseClass.CheckSQLConnection())
            {
                try
                {
                    // create an instance. variable 'con' will hold the instance
                    SqlConnection con = new SqlConnection(_connectionString);
                    con.Open();
                    // Query to populate the Grid
                    string Query = @"SELECT 
	                                cm_mktdata_mdsservice_fits_to_finance_id_unique AS [Id Unique]
                                    ,cm_mktdata_mdsservice_fits_to_finance_MDSService_fits AS [FITS MDSService]
                                    ,cm_mktdata_mdsservice_fits_to_finance_MDSService_finance AS [Finance MDSService]
	                                ,'[ ' + CONVERT(varchar, user_detail_user_info_id_user) + ' ] ' + user_detail_user_info_nm_login AS [Last Modified By]
                                    ,cm_mktdata_mdsservice_fits_to_finance_record_version AS [Record Version]
                                    ,cm_mktdata_mdsservice_fits_to_finance_dt_modified AS [Dt Modified]
	                                ,cm_mktdata_mdsservice_fits_to_finance_ind_active AS [Ind Active]
                                FROM 
	                                dbo.v_mktdata_ui_mdsservice_fits_to_finance_detail
                                WHERE
	                                cm_mktdata_mdsservice_fits_to_finance_ind_operational = 1
                                ORDER BY
	                                cm_mktdata_mdsservice_fits_to_finance_MDSService_fits";
                    SqlCommand createCommand = new SqlCommand(Query, con);
                    createCommand.ExecuteNonQuery();
                    // transfer the results of createCommand to the dataGrid
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(createCommand);
                    DataTable dt = new DataTable("vcm_mktdata_mdsservice_fits_to_finance");
                    dataAdapter.Fill(dt);
                    dataGrid_ServiceName.ItemsSource = dt.DefaultView;
                    dataAdapter.Update(dt);
                    con.Close();
                    // Enable the Refresh Grid Button
                    btn_RefreshGrid_ServiceName.IsEnabled = true;
                    // get DataGrid row count                    
                    lbl_dataGrid_RowCount_ServiceName.Content = dataGrid_ServiceName.Items.Count.ToString() + " rows";
                    //return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                    //return false;
                }
            }
            else
            {
                MessageBox.Show("Connection not established to the SQL Server. " + Environment.NewLine + "The SQL Server may be offline or valid credentials are not yet granted.", "SQL Server Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
            this.Cursor = Cursors.Arrow;
        }
