    DllImport("winmm.dll")]
    private static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
    [DllImport("winmm.dll")]
    private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
    /// <summary>
    /// Returns volume from 0 to 10
    /// </summary>
    /// <returns>Volume from 0 to 10</returns>
    public static int GetVolume()
    {
      uint CurrVol = 0;
      waveOutGetVolume(IntPtr.Zero, out CurrVol);
      ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
      int volume = CalcVol / (ushort.MaxValue / 10);
      return volume;
    }
    /// <summary>
    /// Sets volume from 0 to 10
    /// </summary>
    /// <param name="volume">Volume from 0 to 10</param>
    public static void SetVolume(int volume)
    {
      int NewVolume = ((ushort.MaxValue / 10) * volume);
      uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
      waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
    }
