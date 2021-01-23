    public class ExtendedTextBox : TextBox
        {
            public static readonly DependencyProperty CustomActionProperty =
                DependencyProperty.Register(
                "CustomAction",
                typeof(Action<string>),
                typeof(ExtendedTextBox),
                new PropertyMetadata(null, OnPropertyChanged));
    
            public Action<string> CustomAction 
            {
                get
                {
                    return (Action<string>)GetValue(CustomActionProperty);
                }
                set
                {
                    SetValue(CustomActionProperty, value);
                }
            }
    
            private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if(e.NewValue != null)
                    (d as ExtendedTextBox).TextChanged += ExtendedTextBox_TextChanged;
                else
                    (d as ExtendedTextBox).TextChanged -= ExtendedTextBox_TextChanged;
            }
    
            async static void ExtendedTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {            
                await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => (sender as ExtendedTextBox).CustomAction((sender as ExtendedTextBox).Text));
            }        
        }
