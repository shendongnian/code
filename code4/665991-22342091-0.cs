        public Form1()
        {
            // Disable validation in constructor
            textBox.CausesValidation = false;
        }
        private void OnSaveClicked(object sender, EventArgs e)
        {
            textBox.CausesValidation = true;
            if (ValidateChildren())
            {
                //
                // Do saving of the form data or other processing here ....
                //
                Close();
            }
            //
            // Set validation to false, as user may press Cancel next
            //
            textBox.CausesValidation = false;
        }
        private void OnCancelClicked(object sender, EventArgs e)
        {
            Close();
        }
