    var radioButtons = groupBox1.Controls.OfType<RadioButton>();
    foreach (RadioButton rb in radioButtons)
    {
        bool state = rb.Checked;
        string name = rb.Name;
    }
