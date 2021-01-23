    private void LogOccuredErrors(object sender, ErrorEvent.RoutedCustomEventArgs e)
    {
         ErrorEventHelper eventHelper = e.OccuredEventDetails;
    
     //Call Database Helper to log to database or output to file and email
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(eventHelper.ErrorType);
        builder.AppendLine(eventHelper.ErrorValue);
        builder.AppendLine(eventHelper.ErrorStack);
        if (eventHelper.ShowMessage)
        {
            MessageBox.Show(eventHelper.ErrorValue);
        }
    //Create your log file and email it
        File.WriteAllText(@"C:\log.txt", ControllerBuilder.ToString())
    //email here
    
    }
