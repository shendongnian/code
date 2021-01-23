    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Media.Effects;
    using ViewModels;
    namespace Views
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point scrollStartPoint;
        private Point scrollStartOffset;
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelCreator.Cleanup();
        }
        //protected void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (ScrollViewer.IsMouseOver)
        //    {
        //        // Save starting point, used later when determining 
        //        //how much to scroll.
        //        scrollStartPoint = e.GetPosition(this);
        //        scrollStartOffset.X = ScrollViewer.HorizontalOffset;
        //        scrollStartOffset.Y = ScrollViewer.VerticalOffset;
        //        // Update the cursor if can scroll or not.
        //        this.Cursor = (ScrollViewer.ExtentWidth >
        //           ScrollViewer.ViewportWidth) ||
        //            (ScrollViewer.ExtentHeight >
        //            ScrollViewer.ViewportHeight) ?
        //           Cursors.ScrollAll : Cursors.Arrow;
        //        this.CaptureMouse();
        //    }
        //    base.OnPreviewMouseDown(e);
        //}
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (ScrollViewer.IsMouseOver)
            {
                // Get the new scroll position.
                Point point = e.GetPosition(this);
                // Determine the new amount to scroll.
                Point delta = new Point(
                    (point.X > this.scrollStartPoint.X) ?
                        -(point.X - this.scrollStartPoint.X) :
                        (this.scrollStartPoint.X - point.X),
                    (point.Y > this.scrollStartPoint.Y) ?
                        -(point.Y - this.scrollStartPoint.Y) :
                        (this.scrollStartPoint.Y - point.Y));
                // Scroll to the new position.
                ScrollViewer.ScrollToHorizontalOffset(
                    this.scrollStartOffset.X + delta.X);
                ScrollViewer.ScrollToVerticalOffset(
                    this.scrollStartOffset.Y + delta.Y);
            }
            base.OnPreviewMouseMove(e);
        }
        private void ScrollViewer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ScrollViewer.IsMouseOver)
            {
                // Save starting point, used later when determining 
                //how much to scroll.
                scrollStartPoint = e.GetPosition(this);
                scrollStartOffset.X = ScrollViewer.HorizontalOffset;
                scrollStartOffset.Y = ScrollViewer.VerticalOffset;
                // Update the cursor if can scroll or not.
                this.Cursor = (ScrollViewer.ExtentWidth >
                   ScrollViewer.ViewportWidth) ||
                    (ScrollViewer.ExtentHeight >
                    ScrollViewer.ViewportHeight) ?
                   Cursors.Arrow : Cursors.Arrow;
            }
        }
    }
    }
