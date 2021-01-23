    enter code here
             pt = new packagetariff();
             int var = int.Parse(combo_packTariffID.Text);
               for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
              {
                try
                {
                    pt = new packagetariff();
                    int Id = int.Parse(combo_packTariffID.Text.ToString());
                    DataTable dt = pt.PackageTariff_View(Id);
                    foreach (DataRow dr in dt.Rows)
                    {
                        a = int.Parse(dr[0].ToString());
                    }
                }
                catch { }
                  
                if (a == dataGridView1.Rows.Count - 1)
                    {
                        
                     pt.PackageTariff_Update(var, dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                       
                   }
            }
            
                    if (a != dataGridView1.Rows.Count - 1)
                    {
                        int Id = int.Parse(combo_packTariffID.Text.ToString());
                        pt = new packagetariff();
                        pt.delete_For_Update_tariff(Id);
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                        //pt.PackageTariff_Update(var, dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                        pt.PackageTariff_Add(combo_packTariffID.Text,dataGridView1.Rows[i].Cells[1].Value.ToString(),dataGridView1.Rows[i].Cells[2].Value.ToString(),dataGridView1.Rows[i].Cells[3].Value.ToString(),dataGridView1.Rows[i].Cells[0].Value.ToString());
                        }
                    }
