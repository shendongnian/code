    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace DrawingVisualSample
    {
        public class DrawingVisualElement : FrameworkElement
        {
            private VisualCollection _children;
    
            public DrawingVisual drawingVisual;
    
            public DrawingVisualElement()
            {
                _children = new VisualCollection(this);
                
                drawingVisual = new DrawingVisual();
                _children.Add(drawingVisual);
            }
    
            protected override int VisualChildrenCount
            { 
                get { return _children.Count; } 
            }
    
            protected override Visual GetVisualChild(int index)
            {
                if (index < 0 || index >= _children.Count)
                    throw new ArgumentOutOfRangeException();
    
                return _children[index];
            }
        }
        
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Width = 350;
                Height = 350;
    
                var stackPanel = new StackPanel();
    
                Content = stackPanel;
    
                var drawingVisualElement = new DrawingVisualElement();
    
                stackPanel.Children.Add(drawingVisualElement);
    
                var drawingContext = drawingVisualElement.drawingVisual.RenderOpen();
    
                var random = new Random();
    
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 30; j++)    
                        drawingContext.DrawRectangle(
                            random.Next(2) == 0 ? Brushes.Black : Brushes.Red,
                            (Pen)null,
                            new Rect(i * 10, j * 10, 10, 10));
    
                drawingContext.Close();
            }
        }    
    }
