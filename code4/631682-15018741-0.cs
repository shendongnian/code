        private async void takephoto_click(object sender, RoutedEventArgs e)
        {
   
            var ui = new CameraCaptureUI();
            ui.PhotoSettings.CroppedAspectRatio = new Size(4, 3);
            var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (file != null) 
            {
               // store the file
               var myFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("myImg.jpg");
               await file.MoveAndReplaceAsync(myFile);
               // display the file
               var bitmap = new BitmapImage();
               bitmap.SetSource(await file.OpenAsync(FileAccessMode.Read));
               Photo.Source = bitmap;
            }
        }
        private async void delete_click(object sender, RoutedEventArgs e)
        {
            StorageFile filed = await ApplicationData.Current.LocalFolder.GetFileAsync("myImg.jpg");
            if (filed != null)
            {
                await filed.DeleteAsync();
            }
            StorageFile filefound = await ApplicationData.Current.LocalFolder.GetFileAsync("myImg.jpg");
            if (filefound != null)
            {
               // do something here 
            }
        }
