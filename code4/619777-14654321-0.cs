    private async void Camera_Clicked(object sender, TappedRoutedEventArgs e)
    {       
       CameraCaptureUI camera = new CameraCaptureUI();
       camera.PhotoSettings.CroppedAspectRatio = new Size(16, 9);
       StorageFile photo = await camera.
                              CaptureFileAsync(CameraCaptureUIMode.Photo);
       if (photo != null)
       {
          var targetFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("some_file_name.jpg");
          if (targetFile != null)
          {
             await photo.MoveAndReplaceAsync(targetFile);                 
          }
       }
    }
