    public partial class CustomTextBox : MaskedTextBox
        {
            public CustomTextBox()
            {
                InitializeComponent();
                
                // The properties in the question
                this.BeepOnError = true;
                this.AsciiOnly = true;
            }
            
    }
