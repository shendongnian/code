    somebtton.ClickNoWait() //In case of Button Click
    browser.GoToNoWait()   // In case of pop up appearing just after navigation.
                //Finds the alert dialog if it appears
            AlertDialogHandler AlertDialog = new AlertDialogHandler();
            try
            {
                //Code for checking if the case number is invalid and a dialog box appears.
                Settings.AutoStartDialogWatcher = true;
                Settings.AutoCloseDialogs = true;
                browser.AddDialogHandler(AlertDialog);
                AlertDialog.WaitUntilExists();
                //If alert dialog is found then close the dialog and log error
                if (AlertDialog.Exists())
                {
                    //Click OK button of the dialog so that dialog gets closed
                    AlertDialog.OKButton.Click();
                    browser.WaitForComplete();
                    browser.RemoveDialogHandler(AlertDialog);                    
                }
            }
            catch
            {
                    //Removes the dialog handler if the Dialog dosen't appear within 30 secs.
                    browser.RemoveDialogHandler(AlertDialog);               
            }
