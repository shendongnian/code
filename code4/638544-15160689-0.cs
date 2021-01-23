    private void buttonClear_Text(object sender, EventArgs e)
    {
      ClearSpace(this);
    }
    public static void ClearSpace(Control control)
    {
        foreach (var c in control.Controls.OfType<TextBox>())
        {
            (c).Clear();
            if (c.HasChildren)
                ClearSpace(c);
        }
    }
