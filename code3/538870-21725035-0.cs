        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (parentForm != null)
            {
                parentForm.Closing -= parentForm_Closing;
            }
            parentForm = FindForm();
            if (parentForm != null)
                parentForm.Closing += parentForm_Closing;
        }
        void parentForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parentForm = null;
            //closing code
        }
