    private void listBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (this.listBox1.SelectedIndex >= 0)
                    {
                       string obj = this.listBox1.SelectedValue.ToString();
                       data.Remove(obj);
                    }
                }
            }
