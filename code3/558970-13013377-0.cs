    internal class Log {
        public void Write(string format, params object [] args) {
            File.AppendAllText(@".\log.txt", string.Format(@"{0}, {1}", DateTime.Now, string.Format(format, args)));
        }
    }
