            //update the connections
            foreach (EXCEL.WorkbookConnection connection in workbook.Connections)
            {
                if (connection.Type.ToString() == "xlConnectionTypeODBC")
                {
                    connection.ODBCConnection.BackgroundQuery = false;
                    connection.ODBCConnection.Connection = ConnectionString;
                }
                else
                {
                    connection.OLEDBConnection.BackgroundQuery = false;
                    connection.OLEDBConnection.Connection = ConnectionString;
                }
            }
            //Refresh all data
            workbook.RefreshAll();
