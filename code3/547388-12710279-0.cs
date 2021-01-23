    using System.Windows;
    using System.Windows.Controls;
    
    namespace Test
    {
        public class KeyboardButton : Button
        {
            public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register("SelectedKey", typeof(string),
                typeof(KeyboardButton), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsArrange));
    
            public static readonly DependencyProperty IsUpperCaseProperty = DependencyProperty.Register("IsUpperCase", typeof(bool),
                typeof(KeyboardButton), new FrameworkPropertyMetadata(false));
    
            static KeyboardButton()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(KeyboardButton), new FrameworkPropertyMetadata(typeof(KeyboardButton)));
            }
    
    
            public string SelectedKey
            {
                get { return (string)GetValue(SelectedKeyProperty); }
                set { SetValue(SelectedKeyProperty, value); }
            }
    
    
            public string LowerCaseKey
            {
                get;
                set;
            }
    
            public string UpperCaseKey
            {
                get;
                set;
            }
    
            public bool IsUpperCase
            {
                get { return (bool)GetValue(IsUpperCaseProperty); }
                set { SetValue(IsUpperCaseProperty, value); }
            }
        }
    }
