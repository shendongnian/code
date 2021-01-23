    class UpDownLabel : NumericUpDown
    {
        private Label mLabel;
        private TextBox mBox;
    
        public UpDownLabel()
        {
            mBox = this.Controls[1] as TextBox;
            mBox.Enabled = false;
            mLabel = new Label();
            mLabel.Location = mBox.Location;
            mLabel.Size = mBox.Size;
            this.Controls.Add(mLabel);
            mLabel.BringToFront();
            mLabel.KeyUp += new KeyEventHandler(mLabel_KeyUp);
        }
        
        
        // ignore the KeyUp event in the textarea
        void mLabel_KeyUp(object sender, KeyEventArgs e)
        {
            return;
        }
    
        protected override void UpdateEditText()
        {
            base.UpdateEditText();
            if (mLabel != null) mLabel.Text = mBox.Text;
        }
    }
