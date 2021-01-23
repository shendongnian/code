    <DatePicker x:Name="_DatePicker" CalendarOpened="_DatePicker_CalendarOpened" />
     private void _DatePicker_CalendarOpened(object sender, RoutedEventArgs e) {
            // Finding the calendar that is child of stadart WPF DatePicker
            DatePicker datepicker = (DatePicker)sender;
            Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
            System.Windows.Controls.Calendar cal = (System.Windows.Controls.Calendar)popup.Child;
            cal.DisplayMode = System.Windows.Controls.CalendarMode.Decade;
        }
