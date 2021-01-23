    public interface IDataIO
    {
        //you will have to fill in the types here.  Either the event args
        //the events provide now or byte[] or something relevant would be good.
        IObservable<???> DataReceived;
        IObservable<???> Timeout;
        IObservable<???> Transmit;
    }
    public class IO : IDataIO
    {
        public SerialIO Serial;
        public UdpIO Udp;
        public TcpIO Tcp;
        
        public IObservable<???> DataReceived
        {
            get 
            {
                return Observable.Merge(Serial.DataReceived,
                                        Udp.DataReceived,
                                        Tcp.DataReceived);
            }
        }
        
        //similarly for other two observables
    }
