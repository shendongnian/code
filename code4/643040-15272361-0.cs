    public delegate void CustomTextBoxError(string message);
    public event CustomTextBoxError onError;
    
    private void txtLocl_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(e.KeyChar != '\b')
        {
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled=true;
            }
            else
            {
                 if (onError != null)
                   onError.Invoke("Enter digits only");
            }
        }
    }
