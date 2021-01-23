    public class Capinfos
    {
        private int _packets;
        private string _duration;
    //constructor;
        public Capinfos(string file)
        {
            this.getPackets(file);
            this.getDuration(file);
        }
    private int  getPackets(string file)
    {   
        ///
       
    }
    private string getDuration(string file)
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
