        public static ArrayList GeneralQuery(string thisQuery, OracleConnection myConnection)
        {
            ArrayList outerAL = new ArrayList();
            OracleCommand GeneralCommand = myConnection.CreateCommand();
            GeneralCommand.CommandText = thisQuery;
            OracleDataReader GeneralReader = GeneralCommand.ExecuteReader();
            while (GeneralReader.Read())
            {
                for (int i = 0; i < GeneralReader.FieldCount; i++)
                {
                    ArrayList innerAL = new ArrayList();
                    if (GeneralReader[i] != DBNull.Value)
                    {
                        innerAL.Add(GeneralReader[i]);
                    }
                    else
                    {
                        innerAL.Add(0);
                    }
                    outerAL.Add(innerAL);
                }
            }
            GeneralReader.Close();
            return outerAL;
        }
