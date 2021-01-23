    public interface IFooBar
    {
        string LogMsgNo { get; set; }
        string RevNo { get; set; }
        string ReqSox { get; set; }
        void DoSomething();
    }
    public class Foobar : IFooBar
    {
        public string Logmsgno;
        public string Revno;
        public string Reqsox;
        public void Dosomething();
        public string LogMsgNo
        {
            get { return Logmsgno; }
            set { Logmsgno = value; }
        }
        
        // And so on
    }
