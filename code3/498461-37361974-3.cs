    private void button1_Click(object sender, EventArgs e)
            {
                if (checkReadOnly(textBox2) == true)
                {
                    MessageBox.Show("textbox is readonly");
                }
                else
                {
                    MessageBox.Show("not read only textbox");
                }
            }
