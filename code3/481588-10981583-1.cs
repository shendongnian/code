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
            mLabel.MouseUp += new MouseEventHandler(mLabel_MouseUp);
        }
        
        
        // ignore the KeyUp event in the textarea
        void mLabel_MouseUp(object sender, MouseEventArgs e)
        {
            return;
        }
    
        protected override void UpdateEditText()
        {
            base.UpdateEditText();
            if (mLabel != null) mLabel.Text = mBox.Text;
        }
    }
