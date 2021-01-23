    for (int i = panel1.Controls.Count - 1; i >= 0; i--) {
        if (panel1.Controls[i].Tag == sender) {
            panel1.Controls.RemoveAt(i);
        }
    }
