    string messageBoxText = "Uploading Data";
        string caption = "Upload Data";
        MessageBoxButton button = MessageBoxButton.OKCancel;                
        // Display message box
        MessageBox.Show(messageBoxText, caption, button, icon); //**Comment this line**
        MessageBoxResult res = MessageBox.Show(messageBoxText, caption, button, icon);
        if (res == MessageBoxResult.OK)
        {
           count++;              
        }
