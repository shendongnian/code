    public class SpeedCalculator
    {
        ....
        private Func<int> bts;
        public SpeedCalculator(Func<int> countSource)
        {
            this.bts = countSource;
        }
        ...
        private void QueryByteDelta(object data)
        {
            ....
            bytesDownloadedSinceLastQuery = bts();
        }
    // and in the other file
    private int getbytes() { return bytesDownloaded; }
    public FTPDownloadFile()
    {
        bytesDownloaded = 0;
        Speed = new SpeedCalculator( this.getbytes ); // note it is NOT a getbytes() !
    }
    // or even
    public FTPDownloadFile()
    {
        bytesDownloaded = 0;
        Speed = new SpeedCalculator( () => this.bytesDownloaded ); // CHANGE
    }
