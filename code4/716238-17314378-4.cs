    var textBoxes = Panel1.Controls.OfType<TextBox>().Select((t, i) => new { TextBox = t, Index = i }).ToList();
    foreach (var tb in textBoxes)
    {
        if (string.IsNullOrEmpty(tb.TextBox.Text))
            tb.TextBox.Style["visibility"] = "hidden";
        tb.TextBox.Enabled = false;
    }
    foreach (var line in textBoxes.GroupBy(e => e.Index / 10)
                            .Select(e => 
                                string.Join(", ", 
                                    e.Select(a => a.TextBox.Text).ToArray())))
        stringWriter.WriteLine(line);
