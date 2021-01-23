    string _originalValue;
    
    public OnFocus(){
        _originalValue = TextBox.Text;
        TextBox.Text = "";
    }
    public LostFocus(){
        if(TextBox.Text == "")
            TextBox.Text = _originalValue;
    }
