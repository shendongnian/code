    public interface IByteCountSource
    {
        int BytesDownloaded {get;}
    }
    public class FTPDownloadFile : IDisposable, IByteCountSource
    {
        .....
        public int BytesDownloaded { get { return bytesDownloaded; } }
        .....
        public FTPDownloadFile()
        {
           bytesDownloaded = 0;
           Speed = new SpeedCalculator( this ); // note no change versus Ex#1 !
        }
    }
    public class SpeedCalculator
    {
        ....
        private IByteCountSource bts;
        public SpeedCalculator(IByteCountSource countSource) // no "FTP" information!
        {
            this.bts = countSource;
        }
        ...
        private void QueryByteDelta(object data)
        {
            ....
            bytesDownloadedSinceLastQuery = bts.BytesDownloaded;
        }
