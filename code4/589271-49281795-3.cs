    using System;
    using System.IO.Pipes;
    using System.Threading.Tasks;
    
    namespace Client
    {
        class Program
        {
            public static int threadcounter = 1;
            public static NamedPipeClientStream client;
    
            static void Main(string[] args)
            {
                client = new NamedPipeClientStream(".", "A", PipeDirection.InOut, PipeOptions.Asynchronous);
                client.Connect();
    
                var t1 = new System.Threading.Thread(StartSend);
                var t2 = new System.Threading.Thread(StartSend);
    
                t1.Start();
                t2.Start(); 
            }
    
            public static void StartSend()
            {
                int thisThread = threadcounter;
                threadcounter++;
    
                StartReadingAsync(client);
    
                for (int i = 0; i < 10000; i++)
                {
                    var buf = new byte[1];
                    buf[0] = (byte)i;
                    client.WriteAsync(buf, 0, 1);
    
                    Console.WriteLine($@"Thread{thisThread} Wrote: {buf[0]}");
                }
            }
    
            public static async Task StartReadingAsync(NamedPipeClientStream pipe)
            {
                var bufferLength = 1; 
                byte[] pBuffer = new byte[bufferLength];
    
                await pipe.ReadAsync(pBuffer, 0, bufferLength).ContinueWith(async c =>
                {
                    Console.WriteLine($@"read data {pBuffer[0]}");
                    await StartReadingAsync(pipe); // read the next data <-- 
                });
            }
        }
    }
