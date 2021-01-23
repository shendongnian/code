        public static DependencyProperty SelectedTimeProperty = DependencyProperty.Register("SelectedTime", typeof(TimeSpan), typeof(TimePicker),
            new FrameworkPropertyMetadata((TimeSpan.Zero), new PropertyChangedCallback(OnSelectedTimeChanged)));
        public TimeSpan SelectedTime
        {
            get { return (TimeSpan)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }
        private static void OnHourChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TimePicker tp = (TimePicker)sender;
            //TimePicker tp = new TimePicker();
            var amButton = tp.GetTemplateChild("PART_AmIndicator") as RadioButton;
            var pmButton = tp.GetTemplateChild("PART_PmIndicator") as RadioButton;
            if (pmButton.IsChecked != false)
            {
                tp.SelectedTime = new TimeSpan((int.Parse(tp.Hour) + 12), int.Parse(tp.Minute), 0);
            }
            else if (amButton.IsChecked != false && (tp.Hour == "12"))
            {
                tp.SelectedTime = new TimeSpan(0, int.Parse(tp.Minute), 0);
            }
            else
            {
                tp.SelectedTime = new TimeSpan(int.Parse(tp.Hour), int.Parse(tp.Minute), 0);
            }
        }
        private static void OnMinuteChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //TimePicker tp = new TimePicker();
            TimePicker tp = (TimePicker)sender;
            var amButton = tp.GetTemplateChild("PART_AmIndicator") as RadioButton;
            var pmButton = tp.GetTemplateChild("PART_PmIndicator") as RadioButton;
            if (pmButton.IsChecked != false)
            {
                tp.SelectedTime = new TimeSpan((int.Parse(tp.Hour) + 12), int.Parse(tp.Minute), 0);
            }
            else if (amButton.IsChecked != false && (tp.Hour == "12"))
            {
                tp.SelectedTime = new TimeSpan(0, int.Parse(tp.Minute), 0);
            }
            else
            {
                tp.SelectedTime = new TimeSpan(int.Parse(tp.Hour), int.Parse(tp.Minute), 0);
            }
        }
