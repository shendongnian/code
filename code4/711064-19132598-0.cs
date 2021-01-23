    StorageFolder isoStore = await ApplicationData.Current.LocalFolder.GetFolderAsync("Shared");
            var file = await isoStore.CreateFileAsync("foos1.wmv", CreationCollisionOption.ReplaceExisting);
            using (var s = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                Windows.Foundation.Size resolution = new Windows.Foundation.Size(640, 480);
                avDevice = await AudioVideoCaptureDevice.OpenAsync(CameraSensorLocation.Back,
                    AudioVideoCaptureDevice.GetAvailableCaptureResolutions(CameraSensorLocation.Back).Last());
                VideoBrush videoRecorderBrush = new VideoBrush();
                videoRecorderBrush.SetSource(avDevice);
                viewfinderRectangle.Fill = videoRecorderBrush;
                await avDevice.StartRecordingToStreamAsync(s);
                Thread.Sleep(30000);
                await avDevice.StopRecordingAsync();
            }
            new MediaPlayerLauncher()
            {
                Media = new Uri(file.Path, UriKind.Relative),
            }.Show();
