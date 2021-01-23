    for (int i = 0; i < groupBox.Controls.Count; i++)
    {
        RadioButton rb = (RadioButton)groupBox.Controls[i];
        rb.CheckedChanged += new System.EventHandler(evntHandler);
    }
