    public class TestClass
    {
        private Socket MySocket;
        private static TargettedObserver<bool> SocketConnectedObserver;
        public void Main()
        {
            MySocket = new Socket();
            SocketConnectedObserver = new TargettedObserver<bool>(() => MySocket.Connected);
            SocketConnectedObserver.ValueChanged += ReportSocketConnectedStateChanged;
            PerformSocketConnection();
            MainThread.Invoke(PollSocketValue);
        }
        private void PollSocketValue()
        {
            SocketConnectedObserver.CheckValue();
            MainThread.Invoke(PollSocketValue);
        }
        private void ReportSocketConnectedStateChanged(TargettedObserver<bool> observer, ObservedValueChangedEventArgs<bool> eventArgs)
        {
            Console.WriteLine("Socket connection state changed!  OldValue: " + eventArgs.OldValue + ", NewValue: " + eventArgs.NewValue);
        }
    }
