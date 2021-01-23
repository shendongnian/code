    class ExtendedCheckBox : CheckBox
    {
        protected override void OnCheckedChanged(EventArgs e)
        {
            if (Checked == false)
            {
                base.OnCheckedChanged(e);
            }
            
        }
    }
