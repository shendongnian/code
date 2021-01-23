    public partial class UserControl1 : UserControl
    {
        public Effect MyButtonEffect
        {
            get { return (Effect)GetValue(MyButtonEffectProperty); }
            set { SetValue(MyButtonEffectProperty, value); }
        }
        public static readonly DependencyProperty MyButtonEffectProperty =
            DependencyProperty.Register("MyButtonEffect", typeof(Effect), typeof(UserControl1),
            new FrameworkPropertyMetadata(null, MyButtonEffectPropertyChanged));
        private static void MyButtonEffectPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((UserControl1)obj).myButton.Effect = (Effect)e.NewValue;
        }
    }
