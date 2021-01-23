    public class InputValidator
    {
        public delegate void ValidationDoneDelegate(bool enable);
    
        public event ValidationDoneDelegate ValidationDone;
    
        private List<TextBox> textBoxes = new List<TextBox>();
        private List<ComboBox> comboBoxes = new List<ComboBox>(); 
    
        public void RegisterTextBox(TextBox tb)
        {
            tb.TextChanged += (s, e) => this.Validate();
            textBoxes.Add(tb);
        }
    
        public void RegisterComboBox(ComboBox cb)
        {
            cb.SelectedValueChanged += (s, e) => this.Validate();
            comboBoxes.Add(cb);
        }
    
        private void Validate()
        {
            bool isValid = true;
    
            foreach (var tb in textBoxes)
            {
                if (string.IsNullOrEmpty(tb.Text))
                    isValid = false;
            }
    
            if (isValid)
            {
                foreach (var cb in comboBoxes)
                {
                    if (cb.SelectedItem == null)
                        isValid = false;
                }
            }
    
            var validationDone = ValidationDone;
    
            if (validationDone != null)
            {
                validationDone(isValid);
            }
        }
    }
