        //Store the index of the selected checkbox here as Integer
        private void chkItems_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagridview1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                if (chk.Selected == false)
                {
                    chk.Value = chk.TrueValue;
                }
            }
        }
        //write the function for checking(making true) the user selected checkbox by calling the stored Index
