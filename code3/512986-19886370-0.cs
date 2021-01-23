                con.Open();
                cmd = new SqlCommand("SELECT DISTINCT Tour FROM DetailsTB", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                combo_search2.DisplayMember = "Tour";
                combo_search2.DroppedDown = true;
                List<string> list = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(row.Field<string>("Tour"));
                }
                this.combo_search2.Items.AddRange(list.ToArray<string>());
                combo_search2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                combo_search2.AutoCompleteSource = AutoCompleteSource.ListItems;
                con.Close();
