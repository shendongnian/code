    public class IntegerTextBox : TextBox
    {
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            Text = new String(Text.Where(c => Char.IsDigit(c)).ToArray());
            this.SelectionStart = Text.Length;
        }
    }
