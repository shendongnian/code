    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WinformsWB
    {
        public partial class Form1 : Form
        {
            [DllImport("winmm.dll")]
            public static extern int waveOutGetVolume(IntPtr h, out uint dwVolume);
    
            [DllImport("winmm.dll")]
            public static extern int waveOutSetVolume(IntPtr h, uint dwVolume);
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // save the current volume
                uint _savedVolume;
                waveOutGetVolume(IntPtr.Zero, out _savedVolume);
    
                this.FormClosing += delegate 
                {
                    // restore the volume upon exit
                    waveOutSetVolume(IntPtr.Zero, _savedVolume);
                };
                
                // mute
                waveOutSetVolume(IntPtr.Zero, 0);
                this.webBrowser1.Navigate("http://youtube.com");
            }
        }
    }
