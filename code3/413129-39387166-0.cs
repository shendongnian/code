    public class ElementCultureExtension
    {
        public static bool GetForceCurrentCulture( DependencyObject obj )
        {
            return (bool)obj.GetValue( ForceCurrentCultureProperty );
        }
        public static void SetForceCurrentCulture( DependencyObject obj, bool value )
        {
            obj.SetValue( ForceCurrentCultureProperty, value );
        }
        public static readonly DependencyProperty ForceCurrentCultureProperty =
            DependencyProperty.RegisterAttached(
                "ForceCurrentCulture", typeof( bool ), typeof( ElementCultureExtension ), new PropertyMetadata( false, OnForceCurrentCulturePropertyChanged ) );
        private static void OnForceCurrentCulturePropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e )
        {
            var control = (FrameworkElement)d;
            if( (bool)e.NewValue )
            {
                control.Language = XmlLanguage.GetLanguage( Thread.CurrentThread.CurrentCulture.Name );
            }
        }
    }
