            // Setup Datatable to hold the information
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Number", typeof(int)), 
                new DataColumn("IP Address", typeof(string)),
                new DataColumn("Ping", typeof(int)),
                new DataColumn("GUID", typeof(string)),
                new DataColumn("Name", typeof(string))
            });
            // Get info            
            string info = sendRConCommand("players");
            // Split Rows
            string[] infoRows = info.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int start = 3; // ignore first 3 lines
            while (start < infoRows.Length - 1) // Ignore last line
            {
                // Split row on spaces, and remove anything that is an empty space
                string[] row = infoRows[start].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                DataRow dr = dt.NewRow();
                dr["Number"] = int.Parse(row[0].ToString());
                dr["IP Address"] = row[1].ToString();
                dr["Ping"] = int.Parse(row[2].ToString());
                dr["GUID"] = row[3].ToString();
                int nameItem = 4;
                while (nameItem < row.Length)
                {   // Names can have spaces, so we need to merge
                    dr["Name"] += " " + row[nameItem].ToString();
                    nameItem++;
                }
                dr["Name"] = dr["Name"].ToString().Trim(); // Trim any leading spaces
                dt.Rows.Add(dr);
                start++;
            }
            // Job Done
            mygridview.DataSource = dt;
