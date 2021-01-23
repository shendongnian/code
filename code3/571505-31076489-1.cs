        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                foreach (DataGridViewRow row in dGV1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    
                        chk.Value = chk.TrueValue;
                }
           }
           else if(checkBox2.Checked==true)
           {
                foreach (DataGridViewRow row in dGV1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    chk.Value = 1;
                    if (row.IsNewRow)
                    {
                        chk.Value = 0;
                    }
                }
            }
        }
 
