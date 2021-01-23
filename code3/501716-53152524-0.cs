    var path = @"mytestFile.mp3";
    var mp3ByteArray = File.ReadAllBytes(path);
    var outputStream = new MemoryStream();
    using (var mp3Stream = new MemoryStream(mp3ByteArray))
    using (var reader = new Mp3FileReader(mp3Stream))
    using (var waveFileWriter = new WaveFileWriter(new IgnoreDisposeStream(outputStream), 
                                                   reader.WaveFormat))
    {
    	byte[] buffer = new byte[reader.WaveFormat.AverageBytesPerSecond];
    	int read;
    	while((read = reader.Read(buffer,0, buffer.Length)) > 0)
    	{
    		waveFileWriter.Write(buffer, 0, read);
    	}
    }
    // outputStream has not yet been disposed so we can get the byte array from it
    var wavBytes = outputStream.GetBuffer();
    // or we could play it like this
    outputStream.Position = 0;
    using (var player = new WaveOutEvent())
    using (var reader = new WaveFileReader(outputStream))
    {
    	player.Init(reader);
    	player.Play();
    	while(player.PlaybackState != PlaybackState.Stopped)
    	{
    		Thread.Sleep(1000);
    	}
    }
