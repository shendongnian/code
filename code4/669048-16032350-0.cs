    private string lastUsedTextBox = string.Empty;
    private string lastEnteredValue = string.Empty;
    private void txtJanAmt_KeyPress(object sender, KeyPressEventArgs e)
    {
    lastUsedTextBox = (sender as TextBox).Name;                      
    lastEnteredValue = (sender as TextBox).Text;                       
    }
