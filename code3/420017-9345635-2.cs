    private List<TextBox> _textboxes = new List<TextBox>();
    
    private void GetTextBoxes(Control parent)
    {
        foreach (Control c in parent.Controls) {
            var tb = c as TextBox;
            if (tb != null) {
                _textboxes.Add(tb);
            } else {
                GetTextBoxes(c);
            }
        }
    }
