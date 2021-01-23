            private void txtAnalogValue_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.A)
                {
                    e.SuppressKeyPress = true;
                }
            }
    
            private void txtAnalogValue_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.A)
                {
                    MessageBox.Show("Up");
                }
            }
