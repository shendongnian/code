            DataTable dt = new DataTable("T1");
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("A"), new DataColumn("B"), new DataColumn("C"), new DataColumn("D")});
            for (int i = 0; i < assetdata.Length; i += 4)
            {
                dt.Rows.Add(new string[]{assetdata[i],assetdata[i+1],assetdata[i+2],assetdata[i+3]});
            }
            dataGridView1.DataSource = dt;
