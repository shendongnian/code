    public class ExtendedCombobBox:ComboBox
    {
        public static readonly DependencyProperty MaxSelectedIndexProperty =
            DependencyProperty.Register("MaxSelectedIndex", typeof (int), typeof (ExtendedCombobBox), new PropertyMetadata(default(int)));
        public int MaxSelectedIndex
        {
            get { return (int) GetValue(MaxSelectedIndexProperty); }
            set { SetValue(MaxSelectedIndexProperty, value); }
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (Items.IndexOf(e.AddedItems[0]) > MaxSelectedIndex)
                e.Handled = true;
            else
                base.OnSelectionChanged(e);
        }
    }
