    bool allValid = true;
    for(int c = 0; c < panel.ColumnCount; c++)
    {
        var colRadios = panel.Controls.OfType<RadioButton>() 
            .Where(rb => panel.GetColumn(rb) == c);
        bool colValid = colRadios.Any(rb => rb.Checked);
        if(!colValid)
        {
            allValid = false;
            break;
        }
    }
