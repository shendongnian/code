      void SpecialKeyHandler(object sender, KeyEventArgs e)
    {
        // Ctrl + N
        if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
        {
            MessageBox.Show("New");
        }
        // Ctrl + O
        if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.O))
        {
            MessageBox.Show("Open");
        }
        // Ctrl + S
        if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.S))
        {
            MessageBox.Show("Save");
        }
        // Ctrl + Alt + I
        if ((Keyboard.Modifiers == (ModifierKeys.Alt | ModifierKeys.Control)) && (e.Key == Key.I))
        {
            MessageBox.Show("Ctrl + Alt + I");
        }
    }
