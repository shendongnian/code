    private DataTable GetDataTable()
        {
            // Create an object of DataTable class
            DataTable dataTable = new DataTable("MyDataTable");//Create ID DataColumn
            DataColumn dataColumn_ID = new DataColumn("ID", typeof(Int32));
            dataTable.Columns.Add(dataColumn_ID);//Create another DataColumn Name
            DataColumn dataColumn_Name = new DataColumn("Name", typeof(string));
            dataTable.Columns.Add(dataColumn_Name);
            //Now Add some row to newly created dataTable
            DataRow dataRow;for (int i = 0; i < 5; i++)
            {
                dataRow = dataTable.NewRow();
                // Important you have create New row
                dataRow["ID"] = i;dataRow["Name"] = "Some Text " + i.ToString();
                dataTable.Rows.Add(dataRow);
            }
            dataTable.AcceptChanges();
            return dataTable;
        }
