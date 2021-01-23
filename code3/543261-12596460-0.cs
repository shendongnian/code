            System.IO.StreamReader rdr = new StreamReader(csvPath.Text);
            DataTable dt = new DataTable("Table");
            dt.Columns.Add(new DataColumn("Date"));              
            dt.Columns.Add(new DataColumn("A.TEMP090835"));
            dt.Columns.Add(new DataColumn("Difference"));
		double d=0;
            while ((rowValue = rdr.ReadLine()) != null)
            {
                string[] arr;
                arr = rowValue.Split(',');
                DataRow row = dt.NewRow();
                row["Date"] = arr[0];
                row["A.TEMP090835"] = arr[4];
                row["Difference"] = Convert.ToDouble(arr[4])-d;
                dt.Rows.Add(row);
		d=Convert.ToDouble(arr[4]);
            }
            dt.Rows.RemoveAt(0);
            dataGridView2.DataSource = dt;
            rdr.Close();
