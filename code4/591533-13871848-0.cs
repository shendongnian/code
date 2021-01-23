        private void MakeButton()
        {
            RadioButton rb = new RadioButton
            {
                Appearance = Appearance.Button,
                Tag = "Chevy Camero"
            };
            rb.CheckedChanged += rb_CheckedChanged;
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton clickedButton = sender as RadioButton;
            string currentText = clickedButton.Text;
            clickedButton.Text = clickedButton.Tag.ToString();
            clickedButton.Tag = currentText;
        }
