    class FrmDelivery: Form
    {
        TextBox text1; // Initialize this as usual
        public string DisplayText
        {
           get { return text1.Text; }
           set { text1.Text = Value; }
        }
    } 
