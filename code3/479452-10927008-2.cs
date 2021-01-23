    using System;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    namespace AnimAdornerTest
    {
        public class AnimAdorner : Adorner
        {
            public AnimAdorner(UIElement adornedElement) : base(adornedElement)
            {
                Loaded += AnimAdorner_Loaded;
            }
            void AnimAdorner_Loaded(object sender, RoutedEventArgs e)
            {
                DoubleAnimation myDoubleAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 0.0,
                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                        AutoReverse = true,
                        RepeatBehavior = RepeatBehavior.Forever
                    };
                Storyboard myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                Storyboard.SetTarget(myStoryboard, this);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(OpacityProperty));
                myStoryboard.Begin(this);
            }
            protected override void OnRender(DrawingContext drawingContext)
            {
                Pen renderPen = new Pen(new SolidColorBrush(Colors.Red), 2.5);
                drawingContext.DrawLine(renderPen, new Point(0, 0), new Point(AdornedElement.RenderSize.Width, AdornedElement.RenderSize.Height));
            }
        }
    }
