    private static void PreviewTextInputForDouble(object sender, 
        TextCompositionEventArgs e)
    {
        // e.Text contains only new text and we should create full text manually
    
        var textBox = (TextBox)sender;
        string fullText;
                
        // If text box contains selected text we should replace it with e.Text
        if (textBox.SelectionLength > 0)
        {
            fullText = textBox.Text.Replace(textBox.SelectedText, e.Text);
        }
        else
        {
            // And only otherwise we should insert e.Text at caret position
            fullText = textBox.Text.Insert(textBox.CaretIndex, e.Text);
        }
    
        // Now we should validate our fullText, but not with
        // Double.TryParse. We should use more complicated validation logic.
        bool isTextValid = TextBoxDoubleValidator.IsValid(fullText);
    
        // Interrupting this event if fullText is invalid
        e.Handled = !isTextValid;
    }
