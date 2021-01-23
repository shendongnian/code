      public static void saveAllotmentLeaseToDb(int allotmentId, System.Collections.Generic.List<LeasePatternStruct> arr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AllotmentID",Type.GetType("System.Int32"));
            dt.Columns.Add("LeaseNumber", Type.GetType( "System.Int32"));
            dt.Columns.Add("DueDate",Type.GetType("System.DateTime"));
            dt.Columns.Add("Amount",Type.GetType("System.Double"));
            dt.Columns.Add("Remarks",Type.GetType("System.String"));
            dt.Columns.Add("LeaseIncrementID",Type.GetType("System.Int32"));
            dt.Columns.Add("isPaid",Type.GetType("System.Boolean"));
            dt.Columns.Add("PaymentID", Type.GetType("System.Int32"));
            for (int i = 0; i < arr.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["AllotmentID"] = allotmentId;
                dr["LeaseNumber"] = (i + 1).ToString();
                dr["DueDate"] = arr[i].DueDate;
                dr["Amount"] = arr[i].Amount;
                dr["Remarks"] = arr[i].Remarks;
                dr["LeaseIncrementID"] = DBNull.Value; ;
                dr["isPaid"] = false; ;
                dr["PaymentID"] = DBNull.Value; ;
                dt.Rows.Add(dr);
            }
            using (SqlConnection connection = dataHandler.getConnection())
            {
                connection.Open();
                //Open bulkcopy connection.
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection))
                {
                    //Set destination table name
                    //to table previously created.
                    bulkcopy.DestinationTableName = "LottaryAllotment_Lease_Details";
                   
                        bulkcopy.WriteToServer(dt);
                   
                    connection.Close();
                }
            }
        }
