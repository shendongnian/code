    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Calculate the volume that's being set
            double newVolume = ushort.MaxValue * e.NewValue / 10.0;
            uint v = ((uint) newVolume) & 0xffff;
            uint vAll = v | (v << 16);
            // Set the volume
            int retVal = NativeMethods.WaveOutSetVolume(IntPtr.Zero, vAll);
            Debug.WriteLine(retVal);
        }
    }
    static class NativeMethods
    {
        [DllImport("winmm.dll",EntryPoint = "waveOutSetVolume")]
        public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);
    }
