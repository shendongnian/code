    class MyHandler : IHttpAsyncHandler
    {
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            Stream src = null; // remote data source
            Stream dst = context.Response.OutputStream;
            // set content type, etc
            var res = new MyResult();
            AsynchCopy(src, dst, () =>
                {
                    ((ManualResetEvent)res.AsyncWaitHandle).Set();
                    cb(res);
                    src.Close();
                    dst.Flush();
                });
            return res;
        }
        public void EndProcessRequest(IAsyncResult result)
        {
        }
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
        class MyResult : IAsyncResult
        {
            public MyResult()
            {
                AsyncWaitHandle = new ManualResetEvent(false);
            }
            public object AsyncState
            {
                get { return null; }
            }
            public WaitHandle AsyncWaitHandle
            {
                get;
                private set;
            }
            public bool CompletedSynchronously
            {
                get { return false; }
            }
            public bool IsCompleted
            {
                get { return AsyncWaitHandle.WaitOne(0); }
            }
        }
        public static void AsynchCopy(Stream src, Stream dst, Action done)
        {
            byte[] buffer = new byte[2560];
            AsyncCallback readCallback = null, writeCallback = null;
            readCallback = (readResult) =>
            {
                int read = src.EndRead(readResult);
                if (read > 0)
                {
                    dst.BeginWrite(buffer, 0, read, writeCallback, null);
                }
                else
                {
                    done();
                }
            };
            writeCallback = (writeResult) =>
            {
                dst.EndWrite(writeResult);
                src.BeginRead(buffer, 0, buffer.Length, readCallback, null);
            };
            src.BeginRead(buffer, 0, buffer.Length, readCallback, null);
        }
    }
