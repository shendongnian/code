    public event EventHandler<Form2ResultEventArgs> Form2Result;
    private OnForm2Result(bool checked)
    {
        var handler = Form2Result;
        If (handler != null) {
            handler(this, new Form2ResultEventArgs(checked));
        }
    }
    // Assuming that you have a OK button on Form2
    private OkButton_Click (...)
    {
        OnForm2Result(myCheckBox.Checked);
        this.Close();
    }
