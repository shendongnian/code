    foreach (TextBox textbox in AllTextBoxes(this))
    {
        textbox.ContextMenu = new ContextMenu();
    }
    public IEnumerable<TextBox> AllTextBoxes(Control control)
    {
        List<TextBox> result = new List<TextBox>();
        result.AddRange(control.Controls.OfType<TextBox>());
        foreach (var childControl in control.Controls.OfType<Control>())
        {
            result.AddRange(AllTextBoxes(control));
        }
        return result;
    }
