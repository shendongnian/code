    public class Form2ResultEventArgs : EventArgs
    {
        public Form2ResultEventArgs(bool checked)
        {
            this.Checked = checked;
        }
        public bool Checked { get; private set; }
    }
