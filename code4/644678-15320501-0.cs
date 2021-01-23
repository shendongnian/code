        string oldText = "";
        private void testTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (testTextBlock.Text.Length < oldText.Length)
            {
                testTextBlock.Text = oldText;
                testTextBlock.SelectionStart = oldText.Length;
            }
            else
            {
                oldText = testTextBlock.Text;
            }
        }
