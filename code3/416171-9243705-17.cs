    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) =>
                {
                    if (waiting)
                        stop.Set();
                };
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            var clicked = sender as Button;
            var relatedLabel = this.Controls.Find(clicked.Tag.ToString(), true).FirstOrDefault() as Label;
            if (relatedLabel == null)
                return;
            var playThread = new Thread(() => PlayMp3FromUrl("http://translate.google.com/translate_tts?q=" + HttpUtility.UrlEncode(relatedLabel.Text)));
            playThread.IsBackground = true;
            playThread.Start();
        }
        bool waiting = false;
        AutoResetEvent stop = new AutoResetEvent(false);
        public void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url)
                    .GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }
                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.PlaybackStopped += (sender, e) =>
                        {
                            waveOut.Stop();
                        };
                        waveOut.Play();
                        waiting = true;
                        stop.WaitOne(10000);
                        waiting = false;
                    }
                }
            }
        }
    }
