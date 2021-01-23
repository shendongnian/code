        string m_TextBeforeTheChange;
        int m_CursorPosition = 0;
        bool m_BackPressed = false;
        private void KeyBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            m_TextBeforeTheChange = KeyBox.Text;
            m_BackPressed = (e.Key.Equals(System.Windows.Input.Key.Back)) ? true : false;
        }
        private void KeyBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_BackPressed)
            {
                m_CursorPosition = KeyBox.SelectionStart;
                KeyBox.Text = m_TextBeforeTheChange;
            }
        }
        private void KeyBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            KeyBox.SelectionStart = (m_BackPressed) ? m_CursorPosition + 1 : KeyBox.SelectionStart;
        }
