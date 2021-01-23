    InitializeComponent();
    // connect the leave event for 3 textboxes to the same static method inside the
    // MyUtility static class
    textBox1.Leave+=MyUtility.PadEventForTextBox;
    textBox2.Leave+=MyUtility.PadEventForTextBox;
    textBox3.Leave+=MyUtility.PadEventForTextBox;
    .....
    public static void PadEventForTextBox(object sender, EventArgs e)
    {
        TextBox tb=sender as TextBox;
        if (tb.Text.Length<tb.MaxLength)
            tb.Text=tb.Text.PadLeft(tb.MaxLength, '0');
    }
