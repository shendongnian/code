    using System.Text;
    using System.IO.Ports;
    using System.Threading;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static string serialBuffer = "";
            static string expectedEcho = null;
            static object expectedEchoLock = new object();
            static ManualResetEvent expectedEchoReceived = new ManualResetEvent(false);
            static SerialPort port = new SerialPort("COM1", 19200, Parity.None, 8, StopBits.One);
    
            static void Main(string[] args)
            {
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            }
    
            static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                while (port.BytesToRead > 0)
                {
                    byte[] buffer = new byte[port.BytesToRead];
                    int bytesRead = port.Read(buffer, 0, buffer.Length);
                    serialBuffer += Encoding.UTF8.GetString(buffer);
                    string[] lines = serialBuffer.Split('\r', '\n');
                    // Don't process the last part, because it's not terminated yet
                    for (int i = 0; i < (lines.Length - 1); i++)
                    {
                        if (lines[i].Length > 0)
                            ProcessLine(lines[i]);
                    }
                    serialBuffer = lines[lines.Length - 1]; // keep last part
                }
            }
    
            static void ProcessLine(string line)
            {
                bool unsolicitedMessageReceived = false;
                lock (expectedEchoLock)
                {
                    if (line == expectedEcho)
                    {
                        expectedEchoReceived.Set();
                    }
                    else
                    {
                        unsolicitedMessageReceived = false;
                    }
                }
                if (unsolicitedMessageReceived)
                {
                   // Process unsolicited/unexpected messages
                }
            }
    
            /// <summary>
            /// Send a command and wait for echo
            /// </summary>
            /// <param name="command">The command to send</param>
            /// <returns>True when echo has been received, false on timeout.</returns>
            static bool SendCommand(string command)
            {
                lock (expectedEchoLock)
                {
                    expectedEchoReceived.Reset();
                    expectedEcho = command;
                }
                port.Write(command);
                return expectedEchoReceived.WaitOne(5000); // timeout after 5 seconds
            }
        }
    }
