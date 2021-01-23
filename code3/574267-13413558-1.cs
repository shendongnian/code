     d1 = dtStart;
            d2 = dtEnd;
            foreach (DateTime item in GetDateRange(d1, d2))
            {
                int day = p.GetDayOfMonth(item);
                int month = p.GetMonth(item);
                int year = p.GetYear(item);
                string dt1 = string.Format("{0}/{1}/{2}", year, month, day);
                listBox1.Items.Add(dt1);
            }
            dataGridView1.Rows.Add();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                try
                {
                    dataGridView1.Rows[0].Cells[i].Value = listBox1.Items[i];
                }
                catch (Exception)
                {
                }
            }
