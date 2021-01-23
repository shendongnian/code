    public class Capinfos
    {
        private int _packets;
        private string _duration;
    private void getPackets(string file)
    {   
        /// 
    }
    private void getDuration(string file)
    {   
        ///
    }
        public int packets
        {
            get { return _packets; }
        }
        public string duration
        {
            get { return _duration; }
        }
    public static Capinfos GetFileDetails(string file)
        {
           var info = new Capinfos(file); //allowed, because it's the same class
            info.getNumberOfPackets(file);
            info.getFileDuration(file);
            return info;
        }
