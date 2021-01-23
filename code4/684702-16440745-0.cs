    string myConnectionString= @"Provider=Microsoft.Jet.OLEDB.4.0; Data source=D:\TiptonDB.mdb";
                    string query = "SELECT NodeID FROM NDDINodes";//"SELECT O.NodeID, N.NodeID FROM NDDINodes AS N, NDDINodes AS O WHERE N.X=O.X And N.Y=O.Y And N.NodeID<>O.NodeID";
    
    DataSet dt = new DataSet();
    
    OleDbConnection objXConn = new OleDbConnection(myConnectionString);
                    objXConn.Open();
                    OleDbCommand objCommand = new OleDbCommand(query, objXConn);
                    OleDbDataAdapter adp = new OleDbDataAdapter(objCommand);
                    adp.Fill(dt);
                    objXConn.Close();
                    
