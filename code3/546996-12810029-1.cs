    using System.Windows;
    using System.Windows.Media;
    
    namespace so.ExpCallout
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
    
            private void OnRightButtonClick( object sender, RoutedEventArgs e )
            {
                AdjustCalloutAnchor( RightButton );
                e.Handled = true;
            }
    
            private void OnLeftButtonClick( object sender, RoutedEventArgs e )
            {
                AdjustCalloutAnchor( LeftButton );
                e.Handled = true;
            }
    
            private void AdjustCalloutAnchor( FrameworkElement el )
            {
                // locate the positions of the callout and the element to point to
                Point calloutPoint = MyCallout.TransformToAncestor( LayoutRoot ).Transform( new Point( 0, 0 ) );
                Point elementPoint = el.TransformToAncestor( LayoutRoot ).Transform( new Point( 0, 0 ) );
    
                double vertOffset = calloutPoint.Y + MyCallout.ActualHeight;
                double horizOffset = elementPoint.X;
                if( calloutPoint.X > elementPoint.X )
                {
                    // increase the horizontal offset if the callout 
                    // is to the right of the element
                    horizOffset += el.ActualWidth;
                }
    
                double vertDistance = ( elementPoint.Y + el.ActualHeight ) - vertOffset;
                double horizDistance = calloutPoint.X - horizOffset;
    
                // add some cushion between the element and the new AnchorPoint
                int pad = 5;
    
                // the AnchorPoint is a relative distance based on the actual height
                // and width of the callout.
                double x = ( horizDistance / ( MyCallout.ActualWidth + pad ) ) * -1;
                double y = ( vertDistance / ( MyCallout.ActualHeight + pad ) ) + 1;
    
                // set the new AnchorPoint location
                MyCallout.AnchorPoint = new Point( x, y );
    
                MyCallout.Content = string.Format( "I'm pointing at {0}", el.Name );
            }
        }
    }
