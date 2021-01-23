    class MQ {
        public MQ();
        // send a single message from your message queue
        public void send(string keyPath, string msg);
        // Receive a single message from your message queue
        public async Task<string> receive(keyPath);
    }
