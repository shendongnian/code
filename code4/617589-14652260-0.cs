        AxVLCPlugin vlc;
        public MainWindow()
        {
            InitializeComponent();
            vlc = new AxVLCPlugin();
            windowsFormsHost1.Child = vlc;
            
            vlc.pauseEvent += new EventHandler(vlc_pauseEvent);
            vlc.playEvent += new EventHandler(vlc_playEvent);
            vlc.stopEvent += new EventHandler(vlc_stopEvent);
        }
        void vlc_playEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("playEvent fired!");
        }
        void vlc_pauseEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("pauseEvent fired!");
        }
        void vlc_stopEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("stopEvent fired!");
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                Debug.WriteLine(ofd.FileName);
                vlc.addTarget("file:///" + ofd.FileName, null, AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);
                vlc.play();
            }
        }
