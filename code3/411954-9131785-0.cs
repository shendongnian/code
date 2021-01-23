            private void btnSistemIzle_Click(object sender, EventArgs e)
            {
                txtHKB1.BackColor = Color.Yellow;
                txtHKB2.BackColor = Color.Yellow;
                txtHKB3.BackColor = Color.Yellow;
                txtHKB4.BackColor = Color.Yellow;
                txtHKB1.Text = "";
                txtHKB2.Text = "";
                txtHKB3.Text = "";
                txtHKB4.Text = "";
                SistemIzle("192.168.20.60");            
                SistemIzle("192.168.20.80");
                SistemIzle("192.168.20.100");
                SistemIzle("192.168.20.120");
                counter2++;
            }
