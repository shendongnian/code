    private void MDIParent1_FormClosing(object sender,
    FormClosingEventArgs e)
    {
    if (MessageBox.Show("Close?",
    AppDomain.CurrentDomain.ToString(), MessageBoxButtons.YesNo) ==
    DialogResult.No)
    {
    e.Cancel = true;
    }
    }
