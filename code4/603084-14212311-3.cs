    Form _parentForm;
    public Form2(Form form)
    {
        _parentForm = form;
    }
    
    private void txtForm2_TextChanged(object sender, EventArgs e)
    {
        _parentForm.SetTextboxText(txtForm2.Text); // change Form1.txtForm1.Text
    }
