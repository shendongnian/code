       private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            //allowed char's are 0-9, a-z, A-Z, germanChars, '-' and as extra the {0,40} part where you are able to define the Min and Max Char's
            var matches = Regex.Matches(tb.Text, @"^[0-9a-zA-ZäöüßÄÖÜß''-'\s]{0,40}$");
            if (!(matches.Count > 0))
            {
                MessageBox.Show("Invalid input.", "Text", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Text = "";
            }
        }
