    public class ProperTrackBar : TrackBar
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int oldValue = this.Value;
            switch (keyData)
            {
                case Keys.Up:
                    this.Value = Math.Min(this.Value + this.SmallChange, this.Maximum);
                    break;
                case Keys.Down:
                    this.Value = Math.Max(this.Value - this.SmallChange, this.Minimum);
                    break;
                case Keys.PageUp:
                    this.Value = Math.Min(this.Value + this.LargeChange, this.Maximum);
                    break;
                case Keys.PageDown:
                    this.Value = Math.Max(this.Value - this.LargeChange, this.Minimum);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            if (Value != oldValue)
            {
                OnScroll(EventArgs.Empty);
                OnValueChanged(EventArgs.Empty);
            }
            return true;
        }
    }
