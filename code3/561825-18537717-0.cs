    class MyCalendar : Calendar 
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var cal = this.Template.FindName("PART_CalendarItem", this) as CalendarItem;
            cal.Loaded += new RoutedEventHandler(cal_Loaded);
        }
        void cal_Loaded(object sender, RoutedEventArgs e)
        {
            var cal = sender as CalendarItem;
            var elem = cal.Template.FindName("PART_PreviousButton", cal) as UIElement;
            if (elem != null)
            {
                elem.Visibility = Visibility.Hidden;
            }
            elem = cal.Template.FindName("PART_NextButton", cal) as UIElement;
            if (elem != null)
            {
                elem.Visibility = Visibility.Hidden;
            }
        }
    }
