    List<int> removeIndexes = new List<int>();
    int i = 0;
    foreach (string myItems in listBox1.Items)
                    {
                        using (OracleCommand crtCommand = new OracleCommand(select REGEXP_REPLACE(dbms_metadata.get_ddl('" + myItems + "'), conn1))
                        {
                            string expectedresult = "y";
                            string dataresult = crtCommand.ExecuteScalar().ToString();
                            if (expectedresult == dataresult)
                            {
                              //do something and remove the item that has been used to run the query.                    
                              removeIndexes.add(i);               
                            }
                            else
                            {
                            } 
                         }
                         i++;
                     }
    foreach (int index in removeIndexes)
    {
        listBox1.Items.RemoveAt(index);
    }
