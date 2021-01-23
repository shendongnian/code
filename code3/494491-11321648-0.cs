    public class VaccanoButton : Button
    {        
        static VaccanoButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VaccanoButton), new FrameworkPropertyMetadata(typeof(VaccanoButton)));
        }
        
        public ImageSource FirstImage
        {
            get { return (ImageSource)GetValue(FirstImageProperty); }   
            set { SetValue(FirstImageProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FirstImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstImageProperty =
            DependencyProperty.Register("FirstImage", typeof(ImageSource), typeof(VaccanoButton), new UIPropertyMetadata(null));  
    }
