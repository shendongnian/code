        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                throw new ArgumentException("sender");
            double result;
            var insertedText = e.Text;
            if (!double.TryParse(insertedText, out result) && insertedText != ".")
            {
                e.Handled = true;
            }
            else
            {
                string textboxCurrentValue = textBox.Text;
                int selectionLength = textBox.SelectionLength;
                int selectionStart = textBox.SelectionStart;
                if (selectionLength != 0)
                {
                    textboxCurrentValue = textboxCurrentValue.Remove(selectionStart, selectionLength);
                }
                textboxCurrentValue = textboxCurrentValue.Insert(selectionStart, insertedText);
                if (!double.TryParse(textboxCurrentValue, out result) || result > 5.0D || result < 0.0D)
                {
                    e.Handled = true;
                }
            }
        }
