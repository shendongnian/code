    public class CustomTextBox : TextBox
    {
        public override <propertyName> { get; set; } //auto-implemented property        
        ...
        public CustomTextBox() : base()
        {
             propertyName = newDefualtValue;
             ...
        }
    }
