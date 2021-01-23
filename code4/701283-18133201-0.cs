        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Text;
        using System.Windows.Forms;
        using System.Runtime.InteropServices;
        
        namespace VolumeControl
        {
           public partial class Form1 : Form
           {
              [DllImport("winmm.dll")]
              public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
    
          [DllImport("winmm.dll")]
          public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
    
          public Form1()
          {
             InitializeComponent();
             // By the default set the volume to 0
             uint CurrVol = 0;
             // At this point, CurrVol gets assigned the volume
             waveOutGetVolume(IntPtr.Zero, out CurrVol);
             // Calculate the volume
             ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
             // Get the volume on a scale of 1 to 10 (to fit the trackbar)
             trackWave.Value = CalcVol / (ushort.MaxValue / 10);
          }
    
          private void trackWave_Scroll(object sender, EventArgs e)
          {
             // Calculate the volume that's being set
             int NewVolume = ((ushort.MaxValue / 10) * trackWave.Value);
             // Set the same volume for both the left and the right channels
             uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
             // Set the volume
             waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
          }
       }
    }
