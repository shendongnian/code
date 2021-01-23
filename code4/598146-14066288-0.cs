    if (!cacheHit)
        {
            var stream = await _SpeechSynth.GetSpeakStreamAsync(text, this.Language);
            //write the stream to disk (seems to be buggy when attempting to playback from the result of the speech synth request)
            var audioFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(_AgendaAudioFilename, CreationCollisionOption.ReplaceExisting);
             using(outputStream = await audioFile.OpenAsync(FileAccessMode.ReadWrite)){
             await RandomAccessStream.CopyAsync(stream, outputStream);}
        }
        //read agenda from disk and play back the audio
        var agendaStorageFile = await ApplicationData.Current.TemporaryFolder.GetFileAsync(_AgendaAudioFilename);
       using (var agendaStreamFromDisk = await agendaStorageFile.OpenAsync(FileAccessMode.Read)){
        _MediaPlayer.Url = text;
        _MediaPlayer.SetBytestream(agendaStreamFromDisk);
        _MediaPlayer.Play();  }
