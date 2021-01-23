    void userRegisterOk_DoWork(object sender, DoWorkEventArgs e)
    {
        if (SynchronizationContext.Current != uiCurrent)
        {
            // Wait here - on the background thread
            Thread.Sleep(5000);
            uiCurrent.Post(delegate { userRegisterOk_DoWork(sender, e); }, null);
        }
        else
        {
            // This part is on the GUI thread!!
            ImageResult.Visibility = Visibility.Hidden;
            RotatoryCube.Visibility = Visibility.Visible;
            LabelInsertCard.Content = Cultures.Resources.InsertCard;
        }
    }
