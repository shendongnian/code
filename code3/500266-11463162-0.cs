    public partial class MyWindow : Window
    {
        static MyWindow()
        {
            EventManager.RegisterClassHandler(typeof(FrameworkElement), FrameworkElement.MouseEnterEvent, new MouseEventHandler(MyMouseEventHandler));
        }
    
        public MyWindow()
        {
            InitializeComponent();
        }
    
        static private void MyMouseEventHandler(object sender, MouseEventArgs e)
        {
            // To stop the tooltip from appearing, mark the event as handled
            // But not sure if it is really working
            e.Handled = true;
    
            FrameworkElement source = e.OriginalSource as FrameworkElement;
            if (null != source && null != source.ToolTip)
            {
                // This really disables displaying the tooltip. It is enough only for the current element...
                source.SetValue(ToolTipService.IsEnabledProperty, false);
    
                // Instead write the content of the tooltip into a textblock
                textBoxDescription.Text = source.ToolTip.ToString();
            }
        }
