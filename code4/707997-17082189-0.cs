    public class MaxPerLineTextBox : TextBox
    {
        public MaxPerLineTextBox()
        {
            base.Multiline = true;
        }
        public override bool Multiline
        {
            get
            {
                return true;
            }
            set
            {
                throw new InvalidOperationException("Readonly subclass");
            }
        }
        public int? MaxPerLine { get; set; }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                base.OnKeyPress(e);
                return;
            }
            int maxPerLine;
            if (this.MaxPerLine.HasValue)
            {
                maxPerLine = this.MaxPerLine.Value;
            }
            else
            {
                base.OnKeyPress(e);
                return;           
            }
            var charsAfterNewLine = 
                this.Text.Length - 
                    this.Text.LastIndexOf(
                        Environment.NewLine, 
                        StirngComparison.Ordinal);
            if (charsAfterNewLine < maxPerLine)
            {
                base.OnKeyPress(e);
                return;
            }
            e.Handled = true;
        }
    }
