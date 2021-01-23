    foreach (Control c in availableControls)
    {
        TextBox t = c as TextBox;
        if (t != null && !verify.IsNotEmpty(t.Text, out errorMessage))
            ErrorProvider.SetError(t, errorMessage);
    }
