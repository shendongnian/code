    OleDbCommand MyOleDbComm2 = new OleDbCommand();
                            ObjConn2.Open();
                            MyOleDbComm2.CommandText =
                                "Select fee from table2 " +                                
                                " Where Table2.fdne1='" + textBox1.Text + "'";
                            MyOleDbComm2.Connection = ObjConn2;
                            var result= MyOleDbComm2.ExecuteScalar();
                            ObjConn2.Close();
      
