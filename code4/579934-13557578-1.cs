    try
    {
        private void change_Click(object sender, EventArgs e)
        {
             form1 frm1 = new form();
             frm1.Tag = this.textBox1.text;
             frm1.ShowDialog();
        }
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
