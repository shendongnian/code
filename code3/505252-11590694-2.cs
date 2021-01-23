    namespace Test
    {
        public partial class CustomTextbox : UserControl
        {
            public readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(CustomTextbox), null);
            public readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CustomTextbox), null);
            /// <summary>
            /// Get/set label
            /// </summary>
            public string Label
            {
                get
                {
                    return (string)GetValue(LabelProperty);
                }
                set
                {
                    SetValue(LabelProperty, value);
                }
            }
            /// <summary>
            /// Get/set text property
            /// </summary>
            public string Text
            {
                get
                {
                    return (string)GetValue(TextProperty);
                }
                set
                {
                    SetValue(TextProperty, value);
                }
            }
            public CustomTextbox()
            {
                InitializeComponent();
                DataContext = this;
            }
        }
    }
