            using (var sqlConn = new SqlCeConnection(connStr))
            using (var sqlCmd = new SqlCeCommand(sqlString2, sqlConn))
            {
                sqlConn.Open();
                sqlCmd.Parameters.Add("@VoidBit", SqlDbType.Bit).Value = action;
                sqlCmd.Parameters.Add("@VoidUser", SqlDbType.UniqueIdentifier).Value = DBNull.Value;
                sqlCmd.Parameters.Add("@VoidTimeStamp", SqlDbType.DateTime).Value = DBNull.Value;
                sqlCmd.Parameters.Add("@WoID", SqlDbType.UniqueIdentifier).Value = workOrderID;
                sqlCmd.Parameters.Add("@insGroupNo", SqlDbType.Int).Value = instructionGroupNumber;
                sqlCmd.ExecuteNonQuery();
            }
