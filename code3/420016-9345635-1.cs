    private List<TextBox> _textboxes = new List<TextBox>();
    
    private void GetTextBoxes(Control parent)
    {
        foreach (Control c in parent.Controls) {
            if (c is TextBox) {
                _textboxes.Add((TextBox)c);
            } else {
                GetTextBoxes(c);
            }
        }
    }
