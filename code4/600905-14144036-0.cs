    public static class DependencyPropertyHost
    {
        public static readonly DependencyProperty ReportSourceProperty = DependencyProperty.RegisterAttached("ReportSource", typeof(ReportDocument), typeof(DependencyPropertyHost), new PropertyMetadata(ReportSourceChanged));
        public static ReportDocument GetReportSource(DependencyObject obj)
        {
            return obj.GetValue(ReportSourceProperty) as ReportDocument;
        }
        public static void SetReportSource(DependencyObject obj, ReportDocument value)
        {
            obj.SetValue(ReportSourceProperty, value);
        }
        private static void ReportSourceChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var viewer = sender as CrystalReportsViewer;
            if (viewer != null && args.NewValue != null)
            {
                viewer.ViewerCore.ReportSource = args.NewValue;
            }
        }
    }
