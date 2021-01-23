    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;
    namespace AcpMobile5 {
      class TestClass1 : Form {
        public const int DEF_PORT = 8000;
        private static TcpListener listener;
        public static string Receive(int port) {
          string data = null;
          listener = new TcpListener(IPAddress.Any, port);
          listener.Start();
          using (var client = listener.AcceptTcpClient()) { // waits until data is avaiable
            int MAX = client.ReceiveBufferSize;
            var stream = client.GetStream();
            Byte[] buffer = new Byte[MAX];
            int len = stream.Read(buffer, 0, MAX);
            if (0 < len) {
              data = Encoding.UTF8.GetString(buffer, 0, len);
            }
            stream.Close();
            client.Close();
          }
          return data;
        }
        public static void Send(string message, string host, int port) {
          if (!String.IsNullOrEmpty(message)) {
            if (port < 80) {
              port = DEF_PORT;
            }
            Byte[] data = Encoding.ASCII.GetBytes(message);
            using (var client = new TcpClient(host, port)) {
              var stream = client.GetStream();
              stream.Write(data, 0, data.Length);
              stream.Close();
              client.Close();
            }
          }
        }
      }
    }
