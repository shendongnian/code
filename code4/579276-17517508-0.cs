    private void checkChanged(object sender, EventArgs e)
        {
            foreach (RadioButton r in yourPanel.Controls)
            {
                if (r.Checked)
                    textBox.Text = r.Text;
            }
        }
