      public async void PlayLaserSound()
        {
            var package = Windows.ApplicationModel.Package.Current;
            var installedLocation = package.InstalledLocation;
            var storageFile = await installedLocation.GetFileAsync("Assets\\Sounds\\lazer.mp3");
            if (storageFile != null)
            {
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                MediaElement snd = new MediaElement();
                snd.SetSource(stream, storageFile.ContentType);
                snd.Play();
            }
        }
