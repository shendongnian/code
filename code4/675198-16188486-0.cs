    private void RichTextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z)
        {
            Console.WriteLine("After : " + new TextRange(((RichTextBox)sender).Document.ContentStart, ((RichTextBox)sender).Document.ContentEnd).Text);
        }
    }
    private void RichTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z)
        {
            Console.WriteLine("Before : " + new TextRange(((RichTextBox)sender).Document.ContentStart, ((RichTextBox)sender).Document.ContentEnd).Text);
        }
    }
