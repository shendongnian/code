        public void ReadingTheDataFunction()
        {
            DBDataReader reader = dbCommand.ExecuteReader();
            MyDataStore.FillDataSource(reader)
        }
        private void FillDataSource(DbDataReader reader)
        {
            StreamWriter writer = new StreamWriter(GlobaldataStream);
            while (reader.Read())
                writer.WriteLine(BuildStringFromDataRow(reader));
            reader.close();
        }
        private CustomObject GetNextRow()
        {
            String line = GlobalDataReader.ReadLine();
            //Parse String to Custom Object
            return ret;
        }
