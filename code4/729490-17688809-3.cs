    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1
    {
        public partial class TopBarUserControl : UserControl
        {
            public static readonly DependencyProperty MenuVisibilityProperty = DependencyProperty.Register("MenuVisibility", typeof(Visibility), typeof(TopBarUserControl), null);
            public Visibility MenuVisibility
            {
                get { return (Visibility)GetValue(MenuVisibilityProperty); }
                set { SetValue(MenuVisibilityProperty, value); }
            }
            public TopBarUserControl()
            {
                InitializeComponent();
            }
        }
    }
