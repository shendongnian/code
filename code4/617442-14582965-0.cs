    private DataTable testTable = new DataTable();
            testTable.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("ID", typeof(int)), 
                    new DataColumn("Name", typeof(string)), 
                });
            var row = testTable.NewRow();
            row[0] = 1;
            row[1] = "My Name";
            testTable.Rows.Add(row);
            myTestCmb.ItemsSource = TestTable.AsDataView();
    <ComboBox x:Name ="myTestCmb" DisplayMemberPath="Name" />
