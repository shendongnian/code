    public static void PlayWordAudio(Word word, AxWMPLib.AxWindowsMediaPlayer player)
        {
            string tempFile = Path.GetTempFileName() + ".wav";
            MemoryStream stream = new MemoryStream(word.Audio);
            using (Stream fileStream = File.OpenWrite(tempFile))
            {
                stream.WriteTo(fileStream);
            }
            
            player.URL = tempFile;
            RunDelayed(5000, File.Delete, tempFile); //if we delete file immediately then clip sometimes would not be played
        }        
        public delegate void DelayedFuncion(string param);
        public static void RunDelayed(int delay, DelayedFuncion function, string param = null)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      
            DelayedArgs args = new DelayedArgs() { delayedFunction = function, param = param };
            timer.Tag = args;
            timer.Tick += TimerElapsed;            
            timer.Interval = delay;
            timer.Start();
        }
        private static void TimerElapsed(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            timer.Stop();
            DelayedArgs args = timer.Tag as DelayedArgs;
            args.delayedFunction(args.param);
        }
        class DelayedArgs
    {
        public Util.DelayedFuncion delayedFunction;
        public string param;
    }
