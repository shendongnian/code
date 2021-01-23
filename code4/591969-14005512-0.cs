    public class RequiredTextBox : CompositeControl
    {
        private TextBox _textBox = new TextBox { ID = "T" };
        private RequiredFieldValidator _validator =
            new RequiredFieldValidator { ID = "V", ControlToValidate = "T", ErrorMessage = "*" };
        public string Text
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }
        public string ValidationGroup
        {
            get { return _validator.ValidationGroup; }
            set { _validator.ValidationGroup = value; }
        }
        protected override void CreateChildControls()
        {
            this.Controls.Add(_textBox);
            this.Controls.Add(_validator);
        }
    }
