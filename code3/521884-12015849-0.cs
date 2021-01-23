    public class ColumnEventArgs:EventArgs
    {
        public int ColumnIndex;
    }
    public class ColumnCheckBox:CheckBox
    {
        public int ColumnIndex;
        public event EventHandler<ColumnEventArgs> ColumnCheckedChanged;
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            ColumnEventArgs ce = new ColumnEventArgs();
            ce.ColumnIndex = ColumnIndex;
            ColumnCheckedChanged(this, ce);
        }
    }
