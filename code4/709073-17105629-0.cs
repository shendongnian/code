    private void NumericTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
        {
            e.Handled = true;
            MessageBox.Show("I only accept numbers, sorry. :(", "This textbox says...");
        }
    }
 
