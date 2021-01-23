        public void ProcessData()
        {
            for(var i = 1; i <File.ReadLines(path).Count(); i++)
            {
                var item = File.ReadLine(path);
                DataRow dtRow= dataTable.NewRow();
                dtRow["ID"]= .... //some code here;
                dtRow["Name"]= .... //some code here;
                dtRow["Age"]= .... //some code here;
                if (i%25 == 0)
                {
                    SaveData(/* table name */, /* dataTable */);
                }
            }
            SaveData(/* table name */, /* dataTable */);
        }
        public void SaveData(string tableName, DataTable dataTable )
        {
            //Some code Here
            //After dumping data to DB, clear DataTable
            dataTable.Rows.Clear();
        }
