        private void txtbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (btn != null)
            {
                string letters = txtbox.Text.Substring(txtbox.SelectionStart);
                if (letters.Length > 0)
                    btn.Content = letters[0];
                if (letters.Length > 1)
                    btn2.Content = letters[1];
            }
        }
