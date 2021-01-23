    private async void OnStartRecordingBtnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            m_mediaCaptureMgr = new MediaCapture();
            var settings = new MediaCaptureInitializationSettings();
            settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
            await m_mediaCaptureMgr.InitializeAsync(settings);
               
        }
        catch (Exception exception)
        {
            // Do Exception Handling
        }
    }
    private async void OnStopRecordingBtnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            String fileName;
            if (!m_bRecording)
            {
                fileName = "audio.mp4";
                m_recordStorageFile = await Windows.Storage.KnownFolders.VideosLibrary.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.GenerateUniqueName);
                MediaEncodingProfile recordProfile = null;
                recordProfile = MediaEncodingProfile.CreateM4a(Windows.Media.MediaProperties.AudioEncodingQuality.Auto);
                await m_mediaCaptureMgr.StartRecordToStorageFileAsync(recordProfile, this.m_recordStorageFile);
                m_bRecording = true;
            }
            else
            {
                await m_mediaCaptureMgr.StopRecordAsync();
                m_bRecording = false;
                if (!m_bSuspended)
                {
                    var stream = await m_recordStorageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    playbackElement.AutoPlay = true;
                    playbackElement.SetSource(stream, this.m_recordStorageFile.FileType);
                }
            }
        }
        catch (Exception exception)
        {
            // Do Exception Handling...
            m_bRecording = false;
        }
    }
