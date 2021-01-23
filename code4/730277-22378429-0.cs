    private void button1_Click(object sender, EventArgs e)
            {
                bool chk,chk1;
                int chkq;
                chk = int.TryParse(textBox1.Text, out chkq);
                chk1 = int.TryParse(textBox2.Text, out chkq);
                if (chk1 && chk)
                {
                    MessageBox.Show("Is number");
                }
                else
                {
                    MessageBox.Show("Not a number");
                }
            }
