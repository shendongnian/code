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
            var count = 0;
            var lineLength = this.Lines.Select(line =>
                {
                    count += line.Length;
                    return new { line.Length, count };
                })
                .Last(c => c.count < this.SelectionStart).Length;
            
            if (lineLength < maxPerLine)
            {
                base.OnKeyPress(e);
                return;
            }
            e.Handled = true;
        }
    }
