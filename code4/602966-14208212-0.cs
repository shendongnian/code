    private bool isCaptureInProgress = false;
    private void btnCapture_Click(object sender, RoutedEventArgs e)
    {
        if (isCaptureInProgress)
        {
           MessageBox.Show("Capture is already in progress. Please wait to finish it first");
          return;
         }
        Dispatcher.Invoke(new Action(delegate()
            {
                isCaptureInProgress = true;
                string path = "afinos\\" + "CaptureImage\\" + "CapImage.Jpg";
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);   
                }
                Capture_Helper.SaveImageCapture(pathapp + "\\" + path, (BitmapSource)PicCapture.Source);
                ChangeAvatar_vcard.Source = PicCapture.Source;
                txtPath.Text = pathapp + "\\" + path;
               isCaptureInProgress = false;
            }));
    }
