    public partial class WatermarkTextBox : UserControl, INotifyPropertyChanged
    {
        ...
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkTextProperty", typeof(String),
            typeof(WatermarkTextBox), new PropertyMetadata(null));
    
        public String WatermarkText
        {
            get { return watermarkTextBox.Text; }
            set { OnPropertyChanged("WatermarkText"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
         }
         private void watermarkTextBox_TextChanged(object sender, TextChangedEventArgs e)
         {
               WatermarkText = this.watermarkTextBox.Text;
         }
    
    }
