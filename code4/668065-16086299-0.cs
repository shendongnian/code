    public partial class SimplePopupContent : UserControl
        {
            public SimplePopupContent(string value)
            {
                InitializeComponent();
                textBlockPopUp.Text = value;
            }
    
            private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
            {
                this.Visibility = Visibility.Collapsed;
            }
        } 
