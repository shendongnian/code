    Yournamespace.Helpers
    {
        public string GetTextBoxText(TextBox sender)
        {
            if (sender.Text.Count() < sender.MaxLength)
            return sender.Text.PadLeft(sender.MaxLength, '0');
        }
    }
