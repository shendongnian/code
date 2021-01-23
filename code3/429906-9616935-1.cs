    public partial class VisualDataTemplates : ResourceDictionary
    {
        private Int32 _originalZIndex;
        private const Double _scaleSize = 1.5;
        private const Double _standardScaleSize = 1;
        public VisualDataTemplates()
        {
            InitializeComponent();
        }
        protected void MouseEnter(Object sender, RoutedEventArgs e)
        {
            Border border = sender as Border;
            ContentPresenter presenter = border.TemplatedParent as ContentPresenter;
            
            _originalZIndex = Canvas.GetZIndex(presenter);
            Canvas.SetZIndex(presenter, DisplayOrders.FrontItem);
            SetTransform(border, _scaleSize);
        }
        protected void MouseLeave(Object sender, RoutedEventArgs e)
        {
            Border border = sender as Border;
            ContentPresenter presenter = border.TemplatedParent as ContentPresenter;
            Canvas.SetZIndex(presenter, _originalZIndex);
            SetTransform(border, _standardScaleSize);
           
        }
        private void SetTransform(Border border, Double value)
        {
            ScaleTransform transform = border.RenderTransform as ScaleTransform;
            transform.ScaleX = transform.ScaleY = value;
        }
    }
