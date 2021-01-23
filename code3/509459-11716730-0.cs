    private void RichTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        Dispatcher.BeginInvoke(new Action(UpdateTextBoxCaretPosition));
    }
    void UpdateTextBoxCaretPosition()
    {
        var textRange = new TextRange(rtfBox.Document.ContentStart, rtfBox.CaretPosition);
        plainTextBox.Focus();
        plainTextBox.CaretIndex = textRange.Text.Length;
    }
