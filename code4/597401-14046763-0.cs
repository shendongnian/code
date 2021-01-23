    public class SpeedCalculator
    {
        private const int samples = 5;
        private const int sampleRate = 1000; //In milliseconds
        private int bytesDownloadedSinceLastQuery;
        private System.Threading.Timer queryTimer;
        private Queue<int> byteDeltas = new Queue<int>(samples);
        private FTPDownloadFile downloader; // CHANGE
        public SpeedCalculator(FTPDownloadFile fileDownloader) // CHANGE
        {
            downloader = fileDownloader;
        }
        public void StartPolling()
        {
            queryTimer = new System.Threading.Timer(this.QueryByteDelta, null, 0, sampleRate);
        }
        private void QueryByteDelta(object data)
        {
            if (byteDeltas.Count == samples)
            {
                byteDeltas.Dequeue();
            }
            byteDeltas.Enqueue(_bytesDownloaded - bytesDownloadedSinceLastQuery);
            bytesDownloadedSinceLastQuery = downloader.bytesDownloaded; // CHANGE
        }
    //and in the other file
    public FTPDownloadFile()
    {
        bytesDownloaded = 0;
        Speed = new SpeedCalculator( this ); // CHANGE
    }
