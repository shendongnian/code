        public class StreamTransmitter
        {
            static TaskCompletionSource<bool> ts;
            public static async Task Start(Stream s1, Stream s2, CancellationToken token)
            {
                ts = new TaskCompletionSource<bool>();
                Process(s1, s2, token);
                Process(s2, s1, token);
                await ts.Task;
            }
            private static async Task Process(Stream sIn, Stream sOut, CancellationToken token)
            {
                byte[] buf = new byte[0x10000];
                int len = 0;
                do
                {
                    len = await sIn.ReadAsync(buf, 0, buf.Length, token);
                    await sOut.WriteAsync(buf, 0, len, token);
                }
                while (len > 0 && !token.IsCancellationRequested);
                ts.SetResult(true);
            }
        }
