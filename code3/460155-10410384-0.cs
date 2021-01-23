    public class PasswordBox : TextBox
    {
        private string _realText;
        public string RealText
        {
            get { return this._realText; }
            set
            {
                var i = this.SelectionStart;
                this._realText = value ?? "";
                this.Text = "";
                this.Text = new string('*', this._realText.Length);
                this.SelectionStart = i > this.Text.Length ? this.Text.Length : i;
            }
        }
        private Func<KeyEventArgs, bool> _inputFilter;
        public Func<KeyEventArgs, bool> InputFilter
        {
            get { return this._inputFilter; }
            set { this._inputFilter = value ?? (e => true); }
        }
        public PasswordBox()
        {
            this.RealText = "";
            this.InputFilter = e => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Any(c => c == e.KeyValue);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (this.SelectionStart > 0 || this.SelectionLength > 0)
                    {
                        this.RealText = this.SelectionLength == 0
                                            ? this.RealText.Remove(--this.SelectionStart, 1)
                                            : this.RealText.Remove(this.SelectionStart, this.SelectionLength);
                    }
                    break;
                case Keys.Delete:
                    if (this.SelectionStart == this.TextLength)
                    {
                        return;
                    }
                    this.RealText = this.RealText.Remove(this.SelectionStart, this.SelectionLength == 0 ? 1 : this.SelectionLength);
                    break;
                case Keys.X:
                case Keys.C:
                case Keys.V:
                    if (e.Control)
                    {
                        return;
                    }
                    goto default;
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Shift:
                case Keys.Home:
                case Keys.End:
                    e.SuppressKeyPress = false;
                    base.OnKeyDown(e);
                    break;
                default:
                    if (e.Control)
                    {
                        e.SuppressKeyPress = false;
                        base.OnKeyDown(e);
                        break;
                    }
                    if (this.InputFilter(e))
                    {
                        var c = (char)e.KeyValue;
                        if (e.Shift == IsKeyLocked(Keys.CapsLock))
                        {
                            c = char.ToLower(c);
                        }
                        this.RealText = this.RealText.Remove(this.SelectionStart, this.SelectionLength)
                            .Insert(this.SelectionStart, c.ToString());
                        this.SelectionStart++;
                    }
                    break;
            }
        }
    }
