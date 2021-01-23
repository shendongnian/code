    try
    {
        private void change_Click(object sender, EventArgs e)
        {
             form2 frm2 = new form();
             frm2.Tag = this.textbox2.text;
             frm2.ShowDialog();
        }
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
