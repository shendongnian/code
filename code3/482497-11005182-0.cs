    ComboBox comboBoxToUse;
    if (cboMAIN.SelectedIndex > -1)
    {
        comboBoxToUse = cboMAIN;
    }
    else if (cboMAINalternate.SelectedIndex > -1)
    {
        comboBoxToUse = cboMAINalternate;
    }
    else
    {
        throw new InvalidOperationException("Neither combo box contains a selection.");
    }
    switch (comboBoxToUse.SelectedIndex)
    {
        ...
    }
