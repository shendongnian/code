    private void button2_Click(object sender, EventArgs e)
            {
                foreach(Control ct in Controls.OfType<TextBox>())
                {
                    if (checkReadOnly(ct) == true)
                    {
                        MessageBox.Show(ct.Name + " textbox is readonly");
                    }
                    else
                    {
                        MessageBox.Show(ct.Name + " not read only textbox");
                    }
                }
            }
