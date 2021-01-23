        private void input_TextChanged(object sender, EventArgs e)   
        {   
            if (_preventTextBoxEvents)    
                return;   
   
            _preventTextBoxEvents = true;   
            try
            {
               if (NullMode) input.Text = "";   
               NullMode = false;   
               ValidateInput();   
            }
            catch(Exception ex)
            {
                // Inform user of the exception occurred inside your ValidateInput
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Be sure to restore this global to a functioning value.
                _preventTextBoxEvents = false;   
            }
        }   
