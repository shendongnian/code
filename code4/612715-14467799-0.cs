    public class SelectedDateSyncBehavior
    {
        public static readonly DependencyProperty SyncTextProperty =
            DependencyProperty.RegisterAttached("SyncText", typeof(bool), 
                typeof(SelectedDateSyncBehavior), new PropertyMetadata(false, 
                                                      HandleSyncTextChanged));
        static void HandleSyncTextChanged(DependencyObject d, 
                                          DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
                ((DatePicker)d).LostFocus += SyncText;
            else
                ((DatePicker)d).LostFocus -= SyncText;
        }
        static void SyncText(object sender, RoutedEventArgs e)
        {
            var picker = (DatePicker)sender;
            if (picker.SelectedDate != null)
                picker.Text = picker.SelectedDate.Value.ToShortDateString();
        }
        public static void SetSyncText(DatePicker element, bool value)
        {
            element.SetValue(SyncTextProperty, value);
        }
        public static bool GetSyncText(DatePicker element)
        {
            return (bool)element.GetValue(SyncTextProperty);
        }
    }
