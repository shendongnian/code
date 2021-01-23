    class ExtendedCheckBox : CheckBox
    {
        public event EventHandler Unchecked;
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (Checked == false)
                OnUnchecked(e);
            
        }
        // credit goes to 'lazyberezovsky' for a better implementation for Unchecked event
        protected virtual void OnUnchecked(EventArgs e)
        {
            if (Unchecked != null)
                Unchecked(this, e);
        }
    }
