    string[] lines = lblsubject.Text.Split(',');
    for (int i=0 ; i<lines.Length ; i++)
    {
        var newLabel = new Label();
        newLabel.Text = lines[i];
        form1.Controls.Add(newLabel);
    }
