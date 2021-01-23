    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;
    
    namespace WpfApplication4
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                AdornerLayer myAdornerLayer = AdornerLayer.GetAdornerLayer(myTextBox);
                myAdornerLayer.Add(new SimpleCircleAdorner(myTextBox));
            }
    
            // Adorners must subclass the abstract base class Adorner.
    
            #region Nested type: SimpleCircleAdorner
    
            public class SimpleCircleAdorner : Adorner
            {
                // Be sure to call the base class constructor.
                public SimpleCircleAdorner(UIElement adornedElement)
                    : base(adornedElement)
                {
                }
    
                // A common way to implement an adorner's rendering behavior is to override the OnRender
                // method, which is called by the layout system as part of a rendering pass.
                protected override void OnRender(DrawingContext drawingContext)
                {
                    var adornedElementRect = new Rect(AdornedElement.DesiredSize);
    
                    // Some arbitrary drawing implements.
                    var renderPen = new Pen(new SolidColorBrush(Colors.Red), 1.5);
    
                    drawingContext.DrawLine(renderPen,
                                            new Point(adornedElementRect.TopLeft.X + 75, adornedElementRect.TopLeft.Y),
                                            new Point(adornedElementRect.TopLeft.X + 75, adornedElementRect.TopLeft.Y + 20));
                    drawingContext.DrawLine(renderPen,
                                            new Point(adornedElementRect.TopLeft.X + 120, adornedElementRect.TopLeft.Y + 20),
                                            new Point(adornedElementRect.TopLeft.X + 120, adornedElementRect.TopLeft.Y + 40));
                    drawingContext.DrawLine(renderPen,
                                            new Point(adornedElementRect.TopLeft.X + 120, adornedElementRect.TopLeft.Y + 40),
                                            new Point(adornedElementRect.TopLeft.X + 120, adornedElementRect.TopLeft.Y + 60));
                }
            }
    
            #endregion
        }
    }
