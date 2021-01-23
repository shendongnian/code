    namespace MyApp.Utilities
    {
        public static class TextBoxExtensions
        {
            public static void PadForTextBox(this TextBox tb)
            {
                if (tb.Text.Length < tb.MaxLength)
                    tb.Text = tb.Text.PadLeft(tb.MaxLength, '0');
            }
        }
    }
