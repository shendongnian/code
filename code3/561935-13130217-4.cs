    public partial class Window1 : Window
    {
        private static int oldSelectedIndex = 0;
        public Window1()
        {
            InitializeComponent();
        }
        public RenderTargetBitmap RenderBitmap(FrameworkElement element)
        {
            double topLeft = 0;
            double topRight = 0;
            int width = (int)element.ActualWidth;
            int height = (int)element.ActualHeight;
            double dpiX = 96; // this is the magic number
            double dpiY = 96; // this is the magic number
            PixelFormat pixelFormat = PixelFormats.Default;
            VisualBrush elementBrush = new VisualBrush(element);
            DrawingVisual visual = new DrawingVisual();
            DrawingContext dc = visual.RenderOpen();
            dc.DrawRectangle(elementBrush, null, new Rect(topLeft, topRight, width, height));
            dc.Close();
            RenderTargetBitmap bitmap = new RenderTargetBitmap(width, height, dpiX, dpiY, pixelFormat);
            bitmap.Render(visual);
            return bitmap;
        }
        private void viewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XmlElement root = (XmlElement)viewer.DataContext;
            XmlNodeList xnl = root.SelectNodes("Page");
            if (viewer.ActualHeight > 0 && viewer.ActualWidth > 0)
            {
                RenderTargetBitmap rtb = RenderBitmap(viewer);
                rectanglevisual.Fill = new ImageBrush(BitmapFrame.Create(rtb));
            }
            viewer.ItemsSource = xnl;
            if (oldSelectedIndex < viewList.SelectedIndex)
            {
                viewer.BeginStoryboard((Storyboard)this.Resources["slideLeftToRight"]);
            }
            else
            {
                viewer.BeginStoryboard((Storyboard)this.Resources["slideRightToLeft"]);
            }
            oldSelectedIndex = viewList.SelectedIndex;
        }
        private void SlideToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //The command can always be executed
            e.CanExecute = true;
        }
        private void SlideToPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //When the command is executed, we find the new pagenumber passed as a parameter
            //and switch the selected item of the ListBox, so the animation will run.
            int pagenumber = 0;
            if (int.TryParse(e.Parameter.ToString(), out pagenumber))
            {
                e.Parameter.ToString();
                viewList.SelectedIndex = pagenumber;
            }
        } 
    }
