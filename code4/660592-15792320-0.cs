    public partial class MainShell : UserControl
    {
        #region Private Variables
        private double svHorizontalOffset;
        private double svVerticalOffset;
        #endregion
        #region Constants
        const string JAVASCRIPT_FUNCTION_VERTICALOFFSETCHANGED = "SilverlightScrollViewerVerticalOffest";
        const string JAVASCRIPT_FUNCTION_HORIZONTALOFFSETCHANGED = "SilverlightScrollViewerHorizontalOffest";
        #endregion
        public MainShell(IUnityContainer container)
        {
            InitializeComponent();
            #region Code required registering scroll bar offset notifications
            NotificationHelper.RegisterForNotification("HorizontalOffset", svMainShell, OnHorizontalOffsetChanged);
            NotificationHelper.RegisterForNotification("VerticalOffset", svMainShell, OnVerticalOffsetChanged);
            #endregion
        }
        #region Methods using dependency properties
        public void OnHorizontalOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            svHorizontalOffset = double.Parse(e.NewValue.ToString());
            System.Windows.Browser.HtmlPage.Window.Invoke(JAVASCRIPT_FUNCTION_HORIZONTALOFFSETCHANGED, svHorizontalOffset);
        }
        public void OnVerticalOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            svVerticalOffset = double.Parse(e.NewValue.ToString());
            System.Windows.Browser.HtmlPage.Window.Invoke(JAVASCRIPT_FUNCTION_VERTICALOFFSETCHANGED, svVerticalOffset);
        }
        #endregion
    }
    public class NotificationHelper
    {
        public static void RegisterForNotification(string property, FrameworkElement frameworkElement, PropertyChangedCallback OnCallBack)
        {
            Binding binding = new Binding(property)
            {
                Source = frameworkElement
            };
            var dependencyproperty = System.Windows.DependencyProperty.RegisterAttached("ListenAttached" + property,
                                     typeof(object), typeof(UserControl), new System.Windows.PropertyMetadata(OnCallBack));
            frameworkElement.SetBinding(dependencyproperty, binding);
        }
    }
