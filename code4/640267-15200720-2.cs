    class ExtendedCheckBox : CheckBox
    {
        public event EventHandler Unchecked;
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (Checked == false)
                OnUnchecked(e);
            
        }
    }
