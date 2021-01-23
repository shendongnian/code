     using System;
    using System.Windows;
    
    namespace SO
    {
        public partial class MyDatePicker
        {
            public MyDatePicker()
            {
                InitializeComponent();
            }
    
            public const string SelectedDatePropertyName = "SelectedDate";
    
            public DateTime SelectedDate
            {
                get { return (DateTime)GetValue(SelectedDateProperty); }
                set { SetValue(SelectedDateProperty, value); }
            }
    
            public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register(
                SelectedDatePropertyName,
                typeof(DateTime),
                typeof(MyDatePicker),
                new PropertyMetadata(DateTime.Now, OnSelectedDatePropertyChanged));
    
            private static void OnSelectedDatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((MyDatePicker)d).MyRadDateTimePicker.SelectedDate = (DateTime) e.NewValue;
                ((MyDatePicker)d).MyRadMaskedDateTimeInput.Value = (DateTime)e.NewValue;
            }
        }
    }
