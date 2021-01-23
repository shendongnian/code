    //Show schemas within a server, return a list of string
        public override List<string> showSchema()
        {
            string retrieveSchema = "select distinct owner from dba_objects;";
            List<string> list = new List<string>();
            if (this.OpenConnection() == true)
            {
                //Create Command
                OracleCommand cmd = new OracleCommand(retrieveSchema, conn);
                Console.WriteLine("State: " + conn.State);
                try
                {
                    //Create a data reader and Execute the command
                    OracleDataReader drOracle = cmd.ExecuteReader();
                    //Read the data and store them in the list
                    while (drOracle.Read())
                    {
                        list.Add(drOracle.GetOracleValue(0).ToString() + "");
                    }
                    //close Data Reader
                    drOracle.Close();
                    //close Connection
                    this.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Console.WriteLine("State: " + conn.State);
                }
            }
            //return list to be displayed
            return list;
        }
