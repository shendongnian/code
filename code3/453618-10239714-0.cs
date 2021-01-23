        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TheText.Text.Length == 0) return;
            var text = TheText.Text;
            int result;
            var isValid = int.TryParse(text, out result);
            if (isValid) return;
            TheText.Text = text.Remove(text.Length - 1);
            TheText.SelectionStart = text.Length;
        }
