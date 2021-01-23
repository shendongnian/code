    private void txtFonecom_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back)
        {
        }
        else
        {
            if (txtFonecom.TextLength == 2)
            {
                txtFonecom.Text = txtFonecom.Text + " ";
                txtFonecom.SelectionStart = 3;
                txtFonecom.SelectionLength = 0;
            }
            if (txtFonecom.TextLength == 7)
            {
                txtFonecom.Text = txtFonecom.Text + "-";
                txtFonecom.SelectionStart = 8;
                txtFonecom.SelectionLength = 0;
            }
            if (txtFonecom.TextLength == 12)
            {
                int caretPos = txtFonecom.SelectionStart;
                txtFonecom.Text = txtFonecom.Text.Replace("-", string.Empty).Insert(8, "-");
                txtFonecom.SelectionStart = caretPos;
            }
        }
    }
