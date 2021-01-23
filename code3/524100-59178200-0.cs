        var reader = new WaveFileReader("thirtytwochannels.wav");
        var writers = new WaveFileWriter[reader.WaveFormat.Channels];
        for (int n = 0; n < writers.Length; n++)
        {
            var format = new WaveFormat(reader.WaveFormat.SampleRate, 16, 1);
            writers[n] = new WaveFileWriter(string.Format($"channel{n + 1}.wav"), format);
        }
        float[] buffer;
        while ((buffer = reader.ReadNextSampleFrame())?.Length > 0)
        {
            for(int i = 0; i < buffer.Length; i++)
            {
                // write one sample for each channel (i is the channelNumber)
                writers[i].WriteSample(buffer[i]);
            }
        }
        for (int n = 0; n < writers.Length; n++)
        {
            writers[n].Dispose();
        }
        reader.Dispose();
