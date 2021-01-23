    public class InputValidator
    {
        public delegate void ValidationDoneDelegate(bool enable);
    
        public event ValidationDoneDelegate ValidationDone;
    
        public void RegisterTextBox(TextBox tb)
        {
            tb.TextChanged += (s, e) => this.Validate(s);
        }
    
        public void RegisterComboBox(ComboBox cb)
        {
            cb.SelectedValueChanged += (s, e) => this.Validate(s);
        }
    
        private void Validate(object sender)
        {
            bool isValid = false;
    
            var tb = sender as TextBox;
    
            if (tb != null)
            {
                isValid = !string.IsNullOrEmpty(tb.Text);
            }
            else
            {
                var cb = sender as ComboBox;
    
                if (cb != null)
                {
                    isValid = cb.SelectedItem != null;
                }
                else
                {
                    return;
                }
            }
    
            var validationDone = ValidationDone;
    
            if (validationDone != null)
            {
                validationDone(isValid);
            }
        }
    } 
