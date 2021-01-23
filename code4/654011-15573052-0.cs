    foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var now = DateTime.Now;
                var expirationDate =  DateTime.Parse(row.Cells[0].Value.ToString());
                var sevenDayBefore = expirationDate.AddDays(-7);
                if (now > sevenDayBefore && now < expirationDate)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (now > expirationDate)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;    
                }
            }
