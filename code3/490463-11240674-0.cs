        public static Double GetProjectTitleWidth(DependencyObject obj)
        {
            return (Double)obj.GetValue(ProjectTitleWidthProperty);
        }
        public static void SetProjectTitleWidth(DependencyObject obj, Double value)
        {
            obj.SetValue(ProjectTitleWidthProperty, value);
        }
        public static readonly DependencyProperty ProjectTitleWidthProperty = DependencyProperty.RegisterAttached(
            "ProjectTitleWidth", 
            typeof(Double), 
            typeof(DatawareSearchView),
            new UIPropertyMetadata(0.0, ProjectTitleWidthChanged));
        private static void ProjectTitleWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var targetElement = d as FrameworkElement;
            if (targetElement != null)
            {
                var bindingExpr = targetElement.GetBindingExpression(ProjectTitleWidthProperty);
                var sourceElement = bindingExpr.DataItem as FrameworkElement;
                if (sourceElement != null)
                {
                    // calculating relative offset
                    var leftTop = targetElement.TranslatePoint(new Point(0.0, 0.0), sourceElement);
                    // trying to find ScrollViewer
                    var border = VisualTreeHelper.GetChild(sourceElement, 0);
                    if (border != null)
                    {
                        var scrollViewer = VisualTreeHelper.GetChild(border, 0) as ScrollViewer;
                        if (scrollViewer != null)
                        {
                            // setting width of target element
                            targetElement.Width = scrollViewer.ViewportWidth - leftTop.X;
                        }
                    }
                }
            }
        }
