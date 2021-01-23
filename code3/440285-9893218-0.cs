    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace GapPanel
    {
        public class GapPanel : Panel
        {
            protected override Size MeasureOverride(Size availableSize)
            {
                if (Children.Count == 0)
                    return base.MeasureOverride(availableSize);
                // allot equal space to each child; you may want different logic 
                var spacePerChild = new Size(availableSize.Width / Children.Count,
                                             availableSize.Height);
                foreach (var child in Children)
                    child.Measure(spacePerChild);
                var totalWidth = Children.Sum(child => child.DesiredSize.Width);
                var maxHeight = Children.Max(child => child.DesiredSize.Height);
                return new Size(totalWidth, maxHeight);
            }
    
            protected override Size ArrangeOverride(Size finalSize)
            {
                if (Children.Count == 0)
                    return base.ArrangeOverride(finalSize);
                var gap = (finalSize.Width - Children.Sum(
                           child => child.DesiredSize.Width)) / (Children.Count + 1);
                var spacePerChild = (finalSize.Width - gap * (Children.Count + 1))
                                    / Children.Count;
                for (int i = 0; i < Children.Count; i++)
                {
                    var child = Children[i];
                    child.Arrange(new Rect(i * spacePerChild + (i + 1) * gap, 0,
                                           spacePerChild, finalSize.Height));
                }
                return finalSize;
            }
        }
    }
