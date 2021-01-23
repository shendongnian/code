    for (int i = salesBox.Controls.Count - 1; i >= 0; i--) {
        Control c = salesBox.Controls[i];
        if (c is TextEdit || c is Label) {
            salesBox.Controls.RemoveAt(i);
        }
    }
