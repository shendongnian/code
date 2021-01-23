    public partial class InfoBox : UserControl {
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(String), typeof(InfoBox),
            new FrameworkPropertyMetadata(TextPropertyChanged));
        public static void TextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args) {
            InfoBox infoBox = (InfoBox)sender;
            infoBox.ContentText.Content = args.NewValue;
        }
        public String Text {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
