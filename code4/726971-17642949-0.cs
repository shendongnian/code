        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TextBox tbSender = (TextBox)sender;
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                // Get the next TextBox and focus it.
                DependencyObject nextSibling = GetNextSiblingInVisualTree(tbSender);
                if (nextSibling is Control)
                {
                    // Transfer "keyboard" focus to the target element.
                    ((Control)nextSibling).Focus(FocusState.Keyboard);
                }
            }
        }
