     while (myreader.Read()) 
            {
                HBPData DataEntity = new HBPData();
                DataEntity.NUMBER = (myreader1["NUMBER"].ToString());
                DataEntity.RECNO = (myreader1["RECNO"].ToString());
                DataEntity.CODE = (myreader1["CODE"].ToString());
                DataEntity.DESCRIPTION = (myreader1["ORDD_DESCRIPTION"].ToString());
                DataEntity.Quantity = (myreader1["BVORDQTY"].ToString());
                listofhbpdata2.Add(DataEntity);
            }
            myConnection.Close();
            myreader1.Close();
            myreader.Close();
            System.Data.OleDb.OleDbConnection myAccessConnection = new System.Data.OleDb.OleDbConnection();
            myAccessConnection.ConnectionString = AccessString;
            myAccessConnection.Open();
            System.Data.OleDb.OleDbCommand myAccessCommand3 = new System.Data.OleDb.OleDbCommand("delete from AllOrders", myAccessConnection);
            myAccessCommand3.ExecuteNonQuery();
            for (int i = 0; i < listofhbpdata2.Count(); ++i)
            {
                System.Data.OleDb.OleDbCommand myAccessCommand2 = new System.Data.OleDb.OleDbCommand("" +
                    "Insert into AllOrders VALUES('" +
                      listofhbpdata2[i].NUMBER + "'" + ",'" + listofhbpdata2[i].RECNO.ToString() + "'" +
                    ",'" + listofhbpdata2[i].CODE + "','" + listofhbpdata2[i].DESCRIPTION.Replace("\'", "F") + "'" +
                    ",'" + listofhbpdata2[i].Quantity + "')", myAccessConnection);
                myAccessCommand2.ExecuteNonQuery();
            }
