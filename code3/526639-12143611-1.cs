    var allTextBoxes = txtPanel.Controls.OfType<TextBox>();
    foreach(var kv in dataDict)
    {
        String index = kv.Key;
        String values = String.Join(",", kv.Value);
        TextBox txt = allTextBoxes.FirstOrDefault(txt => txt.Name == "TextBox" + index);
        if(txt != null)
        {
            txt.Text = values;
        }
    }
