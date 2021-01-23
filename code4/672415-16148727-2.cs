    public static class FlowSupport
    {
        public static IEnumerable<string> GetFragments(TextBlock tb) { return (IEnumerable<string>)tb.GetValue(FragmentsProperty); }
        public static void SetFragments(TextBlock tb, IEnumerable<string> value) { tb.SetValue(FragmentsProperty, value); }
        public static readonly DependencyProperty FragmentsProperty = DependencyProperty.RegisterAttached("Fragments", typeof(IEnumerable<string>), typeof(FlowSupport), new PropertyMetadata(new List<string>(), OnFragmentsChanged));
        private static void OnFragmentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tb = d as TextBlock;
            if (tb != null)
            {
                tb.Inlines.Clear();
                var inlines = e.NewValue as IEnumerable<string>;
                if (inlines != null)
                {
                    foreach (string s in inlines)
                        tb.Inlines.Add(s);
                }
            }
        }
    }
