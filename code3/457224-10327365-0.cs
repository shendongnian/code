            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("Postcode", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Rows.Add("Matt", "15 The", "PO30 78", "088997655");
            dataGridView1.DataSource = table;
