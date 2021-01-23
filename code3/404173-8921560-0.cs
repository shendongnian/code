    abstract class Server<T> where T : IConnection
    {
        public abstract void Initialize(ref IConnection conn);
        public abstract void DataSent(T conn, byte[] data);
        public abstract void DataReceived(T conn, byte[] data);
    }
    class SpecialServer : Server<SpecialConnection>
    {
        public override void Initialize(ref IConnection conn)
        {
            conn = new SpecialConnection(conn);
        }
        public override void DataSent(SpecialConnection conn, byte[] data)
        {
            //things
        }
        public override void DataReceived(SpecialConnection conn, byte[] data)
        {
            //stuff
        }
    }
