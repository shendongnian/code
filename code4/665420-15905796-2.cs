        public class BaseExpanderUC : UserControl
        {
            public bool ExpandedByDefault
            {
                get { return (bool)GetValue(ExpandedByDefaultProperty); }
                set { SetValue(ExpandedByDefaultProperty, value); }
            }
            public static readonly DependencyProperty ExpandedByDefaultProperty =
                DependencyProperty.Register("ExpandedByDefault", typeof(bool), typeof(MyBaseView), new UIPropertyMetadata(false));
        }
