    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace SlidingWrapPanel {
        public class GapPanel : Panel, INotifyPropertyChanged {
            private readonly IDictionary<UIElement, int> columns;
            private readonly IDictionary<int, double> gapCoordinates;
            private object opened;
    
            public static readonly DependencyProperty GapColumnProperty =
                DependencyProperty.Register("GapColumn", typeof(int), typeof(GapPanel), new FrameworkPropertyMetadata(default(int), FrameworkPropertyMetadataOptions.AffectsRender, columnChanged));
    
            public static readonly DependencyProperty GapWidthProperty =
                DependencyProperty.Register("GapWidth", typeof(double), typeof(GapPanel), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.AffectsRender));
    
            public static readonly RoutedEvent ColumnChangedEvent;
            public static readonly RoutedEvent CloseGapEvent;
    
            static GapPanel() {
                ColumnChangedEvent = EventManager.RegisterRoutedEvent("ColumnChanged", RoutingStrategy.Bubble, typeof(RoutedEvent), typeof(GapPanel));
                CloseGapEvent = EventManager.RegisterRoutedEvent("CloseGap", RoutingStrategy.Bubble, typeof(RoutedEvent), typeof(GapPanel));
            }
    
            public GapPanel() {
                columns = new Dictionary<UIElement, int>();
                gapCoordinates = new Dictionary<int, double>();
                GapWidth = 0;
                GapColumn = -1;
            }
    
            public int GapColumn {
                get { return (int)GetValue(GapColumnProperty); }
                set { SetValue(GapColumnProperty, value); }
            }
    
            public double GapWidth {
                get { return (double)GetValue(GapWidthProperty); }
                set { SetValue(GapWidthProperty, value); }
            }
    
            public double GapX {
                get {
                    double value;
                    gapCoordinates.TryGetValue(GapColumn, out value);
                    return value;
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public event RoutedEventHandler ColumnChanged {
                add { AddHandler(ColumnChangedEvent, value); }
                remove { RemoveHandler(ColumnChangedEvent, value); }
            }
    
            public event RoutedEventHandler CloseGap {
                add { AddHandler(CloseGapEvent, value); }
                remove { RemoveHandler(CloseGapEvent, value); }
            }
    
            protected override Size ArrangeOverride(Size finalSize) {
                Point location = new Point();
                double position = 0;
                double columnWidth = 0;
                int col = 0;
                foreach (UIElement child in Children) {
                    columnWidth = Math.Max(columnWidth, child.DesiredSize.Width);
                    position += child.DesiredSize.Height;
                    if (position > finalSize.Height && columnWidth > 0) {
                        location.X += columnWidth;
                        if (col == GapColumn) {
                            location.X += GapWidth;
                        }
                        ++col;
                        columnWidth = 0;
                        position = child.DesiredSize.Height;
                        location.Y = 0;
                    }
                    columns[child] = col;
                    child.Arrange(new Rect(location, child.DesiredSize));
    
                    location.Y = position;
                }
    
                return finalSize;
            }
    
            protected override Size MeasureOverride(Size availableSize) {
                double width = 0, height = 0;
                double position = 0;
                double columnWidth = 0;
                int col = 0;
                foreach (UIElement child in Children) {
                    child.Measure(availableSize);
    
                    columnWidth = Math.Max(columnWidth, child.DesiredSize.Width);
                    position += child.DesiredSize.Height;
                    if (position > availableSize.Height && columnWidth > 0) {
                        width += columnWidth;
                        ++col;
                        columnWidth = child.DesiredSize.Width;
                        position = child.DesiredSize.Height;
                        height = Math.Max(height, child.DesiredSize.Height);
                    }
                    gapCoordinates[col] = width + columnWidth;
                }
    
                return new Size(width + GapWidth, height);
            }
    
            protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved) {
                base.OnVisualChildrenChanged(visualAdded, visualRemoved);
                UIElement element = visualAdded as UIElement;
                if (element != null) {
                    element.PreviewMouseLeftButtonDown += expandAtVisual;
                }
                element = visualRemoved as UIElement;
                if (element != null) {
                    element.PreviewMouseLeftButtonDown -= expandAtVisual;
                }
            }
    
            private void expandAtVisual(object sender, MouseButtonEventArgs e) {
                // find element column
                int column = columns[(UIElement)sender];
                GapWidth = 0;
                GapColumn = column;
                if (opened == sender) {
                    RaiseEvent(new RoutedEventArgs(CloseGapEvent, this));
                }
                opened = sender;
            }
    
            private void onPropertyChanged(string propertyName) {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private static void columnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
                ((GapPanel)d).onPropertyChanged("GapX");
                ((GapPanel)d).RaiseEvent(new RoutedEventArgs(ColumnChangedEvent, d));
            }
        }
    }
