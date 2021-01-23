        /// <summary>
        /// Checks for only up to 4 digits and no negatives
        /// in a Numeric Up/Down box
        /// </summary>
        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
                if (numericUpDown1.Text.Length >= 4 || e.KeyValue == 109)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
        }
