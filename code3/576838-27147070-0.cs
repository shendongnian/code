            //Connect to first database table to retreive row/rows and populate dataset + datatable.
            DataSet dataSet = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionStringDEV);
            conn.Open();
            SqlCommand command = new SqlCommand(queryString, conn);
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, conn);
            dataAdapter.FillSchema(dataSet, SchemaType.Mapped);
            dataAdapter.Fill(dataSet, "dbo.DeviceLogs");
            dataTable = dataSet.Tables["dbo.DeviceLogs"];
            conn.Close();
            //Connect to second Database and Insert row/rows.
            SqlConnection conn2 = new SqlConnection(ConnectionStringLOCAL);
            conn2.Open();
            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn2);
            bulkCopy.DestinationTableName = "dbo.DeviceLogs";
            bulkCopy.WriteToServer(dataTable);
            MessageBox.Show(dataTable.Rows.Count.ToString() + "  rows copied successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
