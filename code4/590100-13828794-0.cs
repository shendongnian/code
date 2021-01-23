			for (int i = 1; i <= 12; i++)
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, i, 1);
                DateTime endDate;
                if (i < 12)
                {
                    endDate = (new DateTime(DateTime.Now.Year, i + 1, 1)).AddDays(-1);
                }
                else
                {
                    endDate = (new DateTime(DateTime.Now.Year + 1, 1, 1)).AddDays(-1);
                }
                Debug.WriteLine(startDate.ToString() + " " + endDate.ToString());
                DataView dv = new DataView();
                dv = DtSet.Tables[0].DefaultView;
                string filter = "([Actual Start Date]>= '{0}' and [Actual Start Date] < '{1}')";
                filter = string.Format(filter, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"));
                dv.RowFilter = filter;
                int val = dv.Count;
                
                string controlName = startDate.ToString("MMMM");
                controlName = controlName.Substring(0, 3).ToLower() + "box";
                Control[] cs = this.Controls.Find(controlName, true);
                if (cs != null && cs.Length > 0)
                {
                    // assume the textbox exist and unique
                    TextBox txtbox = (TextBox)(cs[0]);
                    txtbox.Text = val.ToString();
                }
            }
