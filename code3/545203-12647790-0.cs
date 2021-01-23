      NAudio.Wave.WaveFileReader wave = new NAudio.Wave.WaveFileReader(@"C:\test.wav");
      byte[] data = new byte[200];
      int read = wave.Read(data, 0, data.Length);
      for (int i = 0; i < read; i+=2)
      {
            System.Console.WriteLine(BitConverter.ToInt16(data,i));
      }
      System.Console.ReadKey();
