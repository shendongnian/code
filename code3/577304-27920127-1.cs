	using System;
	using NAudio.Wave;
	namespace ConsoleApplication11
	{
		class Program
		{
			static void Main(string[] args)
			{
				// convert source audio to AAC
				// create media foundation reader to read the source (can be any supported format, mp3, wav, ...)
				using (MediaFoundationReader reader = new MediaFoundationReader(@"d:\source.mp3"))
				{
					MediaFoundationEncoder.EncodeToAac(reader, @"D:\test.mp4");
				}
				// convert "back" to WAV
				// create media foundation reader to read the AAC encoded file
				using (MediaFoundationReader reader = new MediaFoundationReader(@"D:\test.mp4"))
				// resample the file to PCM with same sample rate, channels and bits per sample
				using (ResamplerDmoStream resampledReader = new ResamplerDmoStream(reader, 
					new WaveFormat(reader.WaveFormat.SampleRate, reader.WaveFormat.BitsPerSample, reader.WaveFormat.Channels)))
				// create WAVe file
				using (WaveFileWriter waveWriter = new WaveFileWriter(@"d:\test.wav", resampledReader.WaveFormat))
				{
					// copy samples
					resampledReader.CopyTo(waveWriter);
				}
			}
		}
	}
