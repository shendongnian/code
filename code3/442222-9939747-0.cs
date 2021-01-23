    DataSet ds = new DataSet();
      ds.ReadXml("c:\\xmlFile.xml");
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    listView1.Items.Add(item["Name"].ToString());
                }
            }
     
