    int k = 0;
                foreach (DataGridViewColumn c in dgdPrview.Columns)
                {
                    dgdMissingAcc.Columns.Add(c.Clone() as DataGridViewColumn);
                }
    
                for(int i=0;i<dgdPrview.rows.count;i++)
                {
         if (dgdPrview.Rows[k].Cells[i].Style.ForeColor == System.Drawing.Color.Red)
                    {                        
                      dgdMissingAcc.Rows[i].Cells[i].Value=dgdPrview.CurrentRow.Cells[i].value.toString();
                    }
                }
              dgdMissingAcc.Show();
