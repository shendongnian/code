    if (!int.TryParse(e.FormattedValue.ToString(),
                 out newInteger) || newInteger < 0)
    {
       e.Cancel = true;
       ThermalDatGrid.Rows[e.RowIndex].ErrorText = "Only Numerical and Non Negative Values";
    }
    else
    {
       yourButton.Enabled=true;
    }
