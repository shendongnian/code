    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication
    {
        public partial class ValidatingControl : UserControl
        {
            public ValidatingControl()
            {
                InitializeComponent();
            }
    
            public enum Restrictions
            {
                UnsignedIntegersOnly,
                SmallIntegersOnly        
            }
    
            public static readonly DependencyProperty RestrictToProperty =
                DependencyProperty.Register("RestrictTo", typeof(Restrictions), typeof(ValidatingControl), new PropertyMetadata(Restrictions.UnsignedIntegersOnly));
    
            public Restrictions RestrictTo
            {
                get { return (Restrictions)GetValue(RestrictToProperty); }
                set { SetValue(RestrictToProperty, value); }
            }
    
            public bool Valid
            {
                get { return (bool)GetValue(ValidProperty); }
                set { SetValue(ValidProperty, value); }
            }
    
            public static readonly DependencyProperty ValidProperty =
                DependencyProperty.Register("Valid", typeof(bool), typeof(ValidatingControl), new UIPropertyMetadata(false));
    
            private void OnTextChanged(object sender, TextChangedEventArgs e)
            {
                ValidateText(RestrictTo, _textBox.Text);
            }
    
            private void ValidateText(Restrictions restrictTo, string text)
            {
                // validate text, update _messageText, update Valid 
            }
        }
    }
