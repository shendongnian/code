            //Build Sample Data DataTable
            DataTable dt = new DataTable();
            DataColumn dc;
            dc = new DataColumn();
            dc.ColumnName = "Name";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Question";
            dt.Columns.Add(dc);
            dt.Columns.Add("Marks", typeof(int));
            string question = "2D";
            DataRow dr;
            dr = dt.NewRow();
            dr["Name"] = "Fred";
            dr["Question"] = question;
            dr["Marks"] = 54;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Bill";
            dr["Question"] = question;
            dr["Marks"] = 66;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Rhona";
            dr["Question"] = question;
            dr["Marks"] = 32;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Peter";
            dr["Question"] = question;
            dr["Marks"] = 46;
            dt.Rows.Add(dr);
            question = "4D";
            dr = dt.NewRow();
            dr["Name"] = "Fred";
            dr["Question"] = question;
            dr["Marks"] = 89;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Bill";
            dr["Question"] = question;
            dr["Marks"] = 99;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Rhona";
            dr["Question"] = question;
            dr["Marks"] = 28;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Peter";
            dr["Question"] = question;
            dr["Marks"] = 44;
            dt.Rows.Add(dr);
            question = "3D";
            dr = dt.NewRow();
            dr["Name"] = "Fred";
            dr["Question"] = question;
            dr["Marks"] = 26;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Bill";
            dr["Question"] = question;
            dr["Marks"] = 89;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Rhona";
            dr["Question"] = question;
            dr["Marks"] = 73;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Name"] = "Peter";
            dr["Question"] = question;
            dr["Marks"] = 14;
            dt.Rows.Add(dr);
            //Sort the datatable
            DataView dv = dt.DefaultView;
            dv.Sort = "Question ASC, Name ASC";
            dt = dv.ToTable();
            DataTable table = new DataTable();
            table.Columns.Add("Question", typeof(string));
            foreach (DataRow dr2 in dt.Rows)
            {
                //Add user Names to DataTable table
                if (!table.Columns.Contains(dr2["Name"].ToString())) {
                    table.Columns.Add(dr2["Name"].ToString(), typeof(int));
                }
                //Add empty Question rows to DataTable
                if (table.AsEnumerable().Where(x => x.Field<string>("Question") == dr2["Question"].ToString()).Count() == 0)
                {
                    table.Rows.Add(dr2["Question"].ToString());
                }
            }
            // Loop through all columns and questions and then calculate the mark
            for (int i = 1; i < table.Columns.Count;i++ )
            {
                for (int j = 0; j < table.Rows.Count; j++) 
                {
                    string questionName = table.Rows[j][0].ToString();
                    for (int k = 0; k < dt.Rows.Count; k++) 
                    {
                        string userName = table.Columns[i].ColumnName;
                        table.Rows[j][i] = dt.AsEnumerable().Where(x => x.Field<string>("Name") == userName).Where(y=>y.Field<string>("Question") == questionName).Sum(r => r.Field<int>("Marks"));
                    }
                }
            }
            //convert datatable to a IEnumerable form
            var IEtable = (table as System.ComponentModel.IListSource).GetList();
            Chart1.DataBindTable(IEtable, "Question");
