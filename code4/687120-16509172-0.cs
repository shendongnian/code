        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                if (tabControl1.SelectedTab.Controls.Count > 0)
                {
                    if (tabControl1.SelectedTab.Controls[0] is Form2)
                    {
                        Form2 f2 = (Form2)tabControl1.SelectedTab.Controls[0];
                        label1.Text = f2.TextBox1.Text;
                    }
                }
            }
        }
