            public enum EntryState
            {
                Default,
                Power
            }
    
            private EntryState _state = EntryState.Default;
    
            private void buttonxn_Click(object sender, RoutedEventArgs e)
            {
                textBlock1.Text = textBlock1.Text + "x^";
                _state = EntryState.Power;
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                if (_state == EntryState.Power)
                    textBlock1.Text = textBlock1.Text + "\x2070";
                else
                    textBlock1.Text = textBlock1.Text + "1";
            }
