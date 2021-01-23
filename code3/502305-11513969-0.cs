        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
        if (e.Key == Key.A && Keyboard.Modifiers == ModifierKeys.Control)
        {
            MessageBox.Show("CTRL + A Pressed!");
        }
        }
