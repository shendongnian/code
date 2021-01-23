    public string Text {
        get {
            //Default to any existing text
            string s = TextBox1.Text;
            //Use TextBox1.UniqueID to ensure a unique string for the ViewState key
            if (TextBox1.Text.Length == 0 & ViewState(TextBox1.UniqueID) != null) {
                //TextBox1.Text is empty, restore from ViewState
                s = ViewState(TextBox1.UniqueID).ToString;
            }
            return s;
        }
        set {
            //Set TextBox1.Text
            TextBox1.Text = value;
            //Store in ViewState as well
            ViewState(TextBox1.UniqueID) = TextBox1.Text;
        }
    }
