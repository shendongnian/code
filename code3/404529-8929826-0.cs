    public class Chat : Hub {
        public void Distribute(string message) {
            Clients.receive(Caller.name, message);
        }
    }
