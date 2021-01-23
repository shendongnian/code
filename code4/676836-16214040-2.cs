    namespace MyApp.Utilities
    {
        public static class MyUtility
        {
            public static void PadForTextBox(TextBox tb)
            {
                if (tb.Text.Length < tb.MaxLength)
                    tb.Text = tb.Text.PadLeft(tb.MaxLength, '0');
            }
        }
    }
     
