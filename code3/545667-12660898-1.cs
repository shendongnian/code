    private void SetTextBoxReadOnly<T>(Control parent, bool readOnly)
    {
      // Get all TextBoxes and set the value of the ReadOnly property.
      foreach (var tb in parent.Controls.OfType<TextBox>())
        tb.ReadOnly = readOnly;
      // Recurse through all Controls
      foreach(Control c in parent.Controls)
        SetReadOnly<T>(c, readOnly);
    }
