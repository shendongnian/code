    namespace WpfApplication21
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class ResizeThumb : Thumb
        {
            public ResizeThumb()
            {
                DragDelta += new DragDeltaEventHandler(this.ResizeThumb_DragDelta);
            }
    
            private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
            {
                Control designerItem = this.DataContext as Control;
    
                if (designerItem != null)
                {
                    double deltaVertical, deltaHorizontal;
    
                    switch (VerticalAlignment)
                    {
                        case VerticalAlignment.Bottom:
                            deltaVertical = Math.Min(-e.VerticalChange, designerItem.ActualHeight - designerItem.MinHeight);
                            designerItem.Height -= deltaVertical;
                            break;
                        case VerticalAlignment.Top:
                            deltaVertical = Math.Min(e.VerticalChange, designerItem.ActualHeight - designerItem.MinHeight);
                            Canvas.SetTop(designerItem, Canvas.GetTop(designerItem) + deltaVertical);
                            designerItem.Height -= deltaVertical;
                            break;
                        default:
                            break;
                    }
    
                    switch (HorizontalAlignment)
                    {
                        case HorizontalAlignment.Left:
                            deltaHorizontal = Math.Min(e.HorizontalChange, designerItem.ActualWidth - designerItem.MinWidth);
                            Canvas.SetLeft(designerItem, Canvas.GetLeft(designerItem) + deltaHorizontal);
                            designerItem.Width -= deltaHorizontal;
                            break;
                        case HorizontalAlignment.Right:
                            deltaHorizontal = Math.Min(-e.HorizontalChange, designerItem.ActualWidth - designerItem.MinWidth);
                            designerItem.Width -= deltaHorizontal;
                            break;
                        default:
                            break;
                    }
                }
    
                e.Handled = true;
            }
        }
    
    
        public class MoveThumb : Thumb
        {
            public MoveThumb()
            {
                DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
            }
    
            private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
            {
                Control designerItem = this.DataContext as Control;
    
                if (designerItem != null)
                {
                    double left = Canvas.GetLeft(designerItem);
                    double top = Canvas.GetTop(designerItem);
    
                    Canvas.SetLeft(designerItem, left + e.HorizontalChange);
                    Canvas.SetTop(designerItem, top + e.VerticalChange);
                }
            }
        }
    
        public class SizeAdorner : Adorner
        {
            private Control chrome;
            private VisualCollection visuals;
            private ContentControl designerItem;
    
            protected override int VisualChildrenCount
            {
                get
                {
                    return this.visuals.Count;
                }
            }
    
            public SizeAdorner(ContentControl designerItem)
                : base(designerItem)
            {
                this.SnapsToDevicePixels = true;
                this.designerItem = designerItem;
                this.chrome = new Control();
                this.chrome.DataContext = designerItem;
                this.visuals = new VisualCollection(this);
                this.visuals.Add(this.chrome);
            }
    
            protected override Visual GetVisualChild(int index)
            {
                return this.visuals[index];
            }
    
            protected override Size ArrangeOverride(Size arrangeBounds)
            {
                this.chrome.Arrange(new Rect(new Point(0.0, 0.0), arrangeBounds));
                return arrangeBounds;
            }
        }
    }
