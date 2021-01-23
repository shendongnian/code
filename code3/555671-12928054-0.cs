    public class SmtpQueue
    {
        private Queue<string> _queue;
        public SmtpQueue(string[] ips)
        {
            _queue = new Queue<string>();
            LoadIps(ips);
        }
        private void LoadIps(string[] ips)
        {
            // load the ips
            foreach (string ip in ips)
                _queue.Enqueue(ip);
        }
        public string GetNext()
        {
            string nextIp = _queue.Dequeue();
            _queue.Enqueue(nextIp);
            return nextIp;
        }
    }
