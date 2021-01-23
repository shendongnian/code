        private void button2_Click(object sender, EventArgs e)
        {
            //10 column datatable
            var dt10 = new DataTable("DT10");
            dt10.Columns.Add("PKID");
            dt10.Columns.Add("FName"); 
            dt10.Columns.Add("MName");
            dt10.Columns.Add("LName");
            dt10.Columns.Add("Address");
            dt10.Columns.Add("City");
            dt10.Columns.Add("State");
            dt10.Columns.Add("Zip");
            dt10.Columns.Add("Phone");
            dt10.Columns.Add("Fax");
            //give some sample data
            dt10.Rows.Add(new object[] { 1, "Matt", "James", "Smith", "123 Main", "Philadelphia", "PA", "12141", "215-555-1111", "215-555-1212" });
            dt10.Rows.Add(new object[] { 2, "Mark", "James", "Smith", "123 Main", "Pittsburgh", "PA", "12141", "215-555-1111", "215-555-1212" });
            dt10.Rows.Add(new object[] { 3, "Luke", "James", "Smith", "123 Main", "Scranton", "PA", "12141", "215-555-1111", "215-555-1212" });
            dt10.Rows.Add(new object[] { 4, "John", "James", "Smith", "123 Main", "Reading", "PA", "12141", "215-555-1111", "215-555-1212" });
            dt10.Rows.Add(new object[] { 5, "Paul", "James", "Smith", "123 Main", "Harrisburg", "PA", "12141", "215-555-1111", "215-555-1212" });
            //create new datatable with subset of columns
            var dt3 = new DataTable("DT3");
            dt3.Columns.Add("FName");
            dt3.Columns.Add("LName");
            dt3.Columns.Add("Phone");
            
            //indexes can be hardcoded or set at runtime
            int c1 = 1; int c2 = 3; int c3 = 8;
            //add all rows, but only the specified columns
            foreach (DataRow r in dt10.Rows)
            {
                dt3.Rows.Add(new object[] { r[c1], r[c2], r[c3] } );                
            }
            bool includeFirstRow = chkIncludeFirstRow.Checked;
            if (!includeFirstRow)
            {
                dt3.Rows.RemoveAt(0);
            }
            Form2 step2 = new Form2(dt3);
            step2.ShowDialog();
        }
