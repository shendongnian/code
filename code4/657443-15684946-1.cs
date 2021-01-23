    class CCR {
      private Queue<string> m_queue;
      private StreamWriter m_writer;
      public CCR() {
        m_queue = new Queue<string>();
        m_writer = new StreamWriter(string.Format("Log_{0}.txt", DateTime.Now.ToFileTime()));
      }
      public void ExceptionHandler(Exception ex, string location) {
        string item = string.Format("{0:u}: {1}\r\n\t\t{2}", DateTime.Now, location, ex.Message);
        if (ex.InnerException == null) {
          m_queue.Enqueue(item);
        } else {
          m_queue.Enqueue(item + string.Format("\r\n\t\tInner Exception: {0}", ex.InnerException.Message));
        }
        QueueHandler();
      }
      private void QueueHandler() {
        while (0 < m_queue.Count) {
          m_writer.WriteLine(m_queue.Dequeue());
        }
      }
      public void Close() {
        QueueHandler();
        m_writer.Flush();
        m_writer.Close();
        m_writer.Dispose();
      }
