    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // I used Interop call to play music instead of wmp
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand,
                                                 StringBuilder strReturn,
                                                 int iReturnLength,
                                                 IntPtr hwndCallback);
        private void glowingButton1_Click(object sender, EventArgs e)
        {
            // play song or whatever you want to do
            mciSendString("open \"" + @"e:\temp\keine zeit.mp3" + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);
        }
    }
