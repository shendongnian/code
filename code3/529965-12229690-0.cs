    if (emails.SelectedItem != null) {
        string text = emails.SelectedItem.ToString();
        for (int i = 1; i < text.Length; i++) {
            string textWithPeriod = text.Substring(0, i) + "." + text.Substring(i);
            clone.Items.Add(textWithPeriod); 
        }
    }
