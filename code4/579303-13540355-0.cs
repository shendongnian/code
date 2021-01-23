    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ReadStreamAsyncTask
    {
        internal class Program
        {
            private static CancellationToken _cancelTaskSignal;
            private static byte[] _serialPortBytes;
            private static MemoryStream _streamOfBytesFromPort;
            private static CancellationTokenSource _cancelTaskSignalSource;
    
            private static void Main()
            {
                _serialPortBytes = Encoding.ASCII.GetBytes("Mimic a bunch of bytes from the serial port");
                _streamOfBytesFromPort = new MemoryStream(_serialPortBytes);
                _streamOfBytesFromPort.Position = 0;
    
                _cancelTaskSignalSource = new CancellationTokenSource();
                _cancelTaskSignal = _cancelTaskSignalSource.Token; // Used to request cancel the task if needed.
    
                var readFromSerialPort = Task.Factory.StartNew(ReadStream, _cancelTaskSignal);
                readFromSerialPort.Wait(3000); // wait until task is complete(or errors) OR 3 seconds
    
                Console.WriteLine("Press enter to cancel the task");
                _cancelTaskSignalSource.Cancel();
                Console.ReadLine();
            }
    
            private static void ReadStream()
            {
                // start your loop here to read from the port and print to console
    
                Console.WriteLine("Port read task started");
    
                int bytesToReadCount = Buffer.ByteLength(_serialPortBytes);
                var localBuffer = new byte[bytesToReadCount];
    
                int bytesRead = 0;
    
                bool finishedReading = false;
    
                try
                {
                    while (!finishedReading)
                    {
                        _cancelTaskSignal.ThrowIfCancellationRequested();
    
                        bytesRead += _streamOfBytesFromPort.Read(localBuffer, 0, bytesToReadCount);
    
                        finishedReading = (bytesRead - bytesToReadCount == 0);
                    }
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("You cancelled the task");
                }
    
                Console.WriteLine(Encoding.ASCII.GetString(localBuffer));
                Console.WriteLine("Done reading stream");
            }
        }
    }
