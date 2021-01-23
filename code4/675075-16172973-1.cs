    public class AttachedProperties : DependencyObject //adds a bindable DialogResult to window
    {
        public static readonly DependencyProperty DialogResultProperty = 
            DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(AttachedProperties), 
            new PropertyMetaData(default(bool?), OnDialogResultChanged));
 
        public bool? DialogResult
        {
            get { return (bool?)GetValue(DialogResultProperty); }
            set { SetValue(DialogResultProperty, value); }
        }
        private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window == null)
                return;
            window.DialogResult = (bool?)e.NewValue;
        }
    }
