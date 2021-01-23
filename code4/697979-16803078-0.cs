    public class MyTrackBar : TrackBar
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    this.Value = Math.Min(this.Value + this.SmallChange, this.Maximum);
                    return true;
                case Keys.Down:
                    this.Value = Math.Max(this.Value - this.SmallChange, this.Minimum);
                    return true;
                case Keys.PageUp:
                    this.Value = Math.Min(this.Value + this.LargeChange, this.Maximum);
                    return true;
                case Keys.PageDown:
                    this.Value = Math.Max(this.Value - this.LargeChange, this.Minimum);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
