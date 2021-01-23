      for (int i = listBox1.Items.Count -1; i>=0; i--)
          {
                string myItems = listBox1.Items[i];
                using (OracleCommand crtCommand = new OracleCommand(select REGEXP_REPLACE(dbms_metadata.get_ddl('" + myItems + "'), conn1))
                            {
                                string expectedresult = "y";
                                string dataresult = crtCommand.ExecuteScalar().ToString();
                                if (expectedresult == dataresult)
                                {
                                   listBox1.RemoveAt(0);
                               }
                                else
                                {
    
                                } 
                             }
                         }
