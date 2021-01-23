     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (MessageBox.Show("Do you want to Print/View P.O? Please be patient as P.O may take few seconds to load.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    pl.POId = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    DataTable dt = new DataTable();
                    dt = bl.PurchaseOrderPrint(pl);
                    if (dt.Rows.Count > 0)
                    {
                        Reports.PuchaseOrder rpt = new Reports.PuchaseOrder();
                        Print f = new Print();
                        rpt.SetDataSource(dt);
                        f.CRV.ReportSource = rpt;
                        f.Show();
                    }
                }
                else
                {
                    return;
                }
            }
