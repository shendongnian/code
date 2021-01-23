    private void listBox1_MouseDown(object sender, MouseEventArgs e)
    {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int index = listBox1.IndexFromPoint(e.Location);
                {
                    if (index == listBox1.SelectedIndex)
                    {
                        MessageBox.Show("Selected item clicked");
                    }
                }
            }
    }
