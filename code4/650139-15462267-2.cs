        public void ProcessData()
        {
            int i = 1;
            foreach(var item in File.ReadLines(path)) //This line has been edited
            {
                DataRow dtRow= dataTable.NewRow();
                dtRow["ID"]= .... //some code here;
                dtRow["Name"]= .... //some code here;
                dtRow["Age"]= .... //some code here;
                if (i%25 == 0) //you can change the 25 here to something else
                {
                    SaveData(/* table name */, /* dataTable */);
                }
                i++;
            }
            SaveData(/* table name */, /* dataTable */);
        }
        public void SaveData(string tableName, DataTable dataTable )
        {
            //Some code Here
            //After dumping data to DB, clear DataTable
            dataTable.Rows.Clear();
        }
