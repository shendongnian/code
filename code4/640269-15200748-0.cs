    public class StrageCheckBox : CheckBox
    {
        public event EventHandler Unchecked;
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (!Checked)
                OnUnchecked(e);
        }
        protected virtual void OnUnchecked(EventArgs e)
        {
            if (Unchecked != null)
                Unchecked(this, e);
        }
    }
