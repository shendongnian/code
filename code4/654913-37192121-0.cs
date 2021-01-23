    private void button1_Click(object sender, EventArgs e)
        {
            SetReadonlyControls(groupBox1.Controls);
        }
    
        private void SetReadonlyControls(Control.ControlCollection controlCollection)
        {
            if (controlCollection == null)
            {
                return;
            }
            foreach (RadioButton r in controlCollection.OfType<RadioButton>())
            {
                r.Enabled = false; //RadioButtons do not have readonly property
            }
            foreach (ComboBox c in controlCollection.OfType<ComboBox>())
            {
                c.Enabled = false;//ComboBoxes do not have readonly property
            }
            foreach (TextBoxBase c in controlCollection.OfType<TextBoxBase>())
            {
                c.ReadOnly = true;
            }
        }
