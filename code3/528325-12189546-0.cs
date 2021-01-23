    public class NumericUpDownEx : NumericUpDown 
    {
        public NumericUpDownEx() {
            // Optionally set other control properties here.
            this.Maximum = 10;
            this.Minimum = 0;
            this.DecimalPlaces = 1;
            this.Increment = ,5m;
        }
        protected override void UpdateEditText() {
            // Remove any trailing ',5'.
            this.Text = this.Value.ToString().Replace(".0", string.Empty);
        } 
    }
