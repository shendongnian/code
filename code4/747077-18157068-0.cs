    public static void AddMediaFilesToMediaList()
    {
        MediaFileCreator mfCreator = new MediaFileCreator();
   
        while (MediaFilesQueue.Count > 0)
        {
            // all the files are loaded into the Queue before processing
            string pathToFile = MediaFilesQueue.Dequeue();
            MediaFile mf = mfCreator.CreateNewMediaFile(pathToFile);
 
            MediaData.MediaList.Add(mf);
        }
    }
    public class MediaFileCreator
    {
        private MediaPlayer player = new MediaPlayer();
        private ManualResetEvent openedEvent = new ManualResetEvent(false);
        public MediaFileCreator()
        {
            player.MediaOpened = MediaOpened;
        }
        private void MediaOpened(object sender, EventArgs args)
        {
            openedEvent.Set();
        }
        public MediaFile CreateNewMediaFile(string filename)
        {
            openedEvent.Reset();
            player.Open(new Uri(tempMediaFile.PathToFile));
            // wait for it to load
            openedEvent.WaitOne();
            MediaFile mf = new MediaFile(filename);
            mf.HasVideo = player.HasVideo;
            mf.HasAudio = player.HasAudio;
            mf.TimeSpanOfMediaFile = player.NaturalDuration.TimeSpan;
            player.Close();
            return mf;
        }
    }
