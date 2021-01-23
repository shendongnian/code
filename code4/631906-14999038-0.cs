    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
    {
        DatePicker datepicker = (DatePicker)sender;
        Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
        Calendar cal = (Calendar)popup.Child;
        cal.DisplayMode = CalendarMode.Year;
    }
