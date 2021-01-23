            Dictionary<String, String> dict = new Dictionary<String,String>();
            dict.Add("Filename1","Error1");
            dict.Add("Filename2","Error2");
            dict.Add("Filename3","Error3");
            DataTable table = new DataTable();
 
            table.Columns.Add("Filename", typeof(String));
            table.Columns.Add("Error_Description", typeof(String));
 
            foreach (KeyValuePair<String,String> dictval in dict)
                {
                    table.Rows.Add(dictval.Key, dictval.Value);
                }
            dataGridView1.DataSource = table;
