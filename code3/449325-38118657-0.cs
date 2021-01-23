    private void btnCancel_MouseEnter(object sender, EventArgs e)
            {
                AutoValidate = AutoValidate.Disable;
            }
    private void btnCancel_MouseLeave(object sender, EventArgs e)
            {
                AutoValidate = AutoValidate.EnablePreventFocusChange;
            }
