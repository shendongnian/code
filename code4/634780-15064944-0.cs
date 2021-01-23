    public class AsyncSocketWrapper : IDisposable
    {
        public void Dispose()
        {
            var tmp = socket;
            socket = null;
            if(tmp != null) tmp.Dispose();
        }
        public AsyncSocketWrapper(Socket socket)
        {
            this.socket = socket;
            args = new SocketAsyncEventArgs();
            args.Completed += args_Completed;
        }
        void args_Completed(object sender, SocketAsyncEventArgs e)
        {
            // might want to switch on e.LastOperation
            var source = (TaskCompletionSource<int>)e.UserToken;
            if (ShouldSetResult(source, args)) source.TrySetResult(args.BytesTransferred);
        }
        private Socket socket;
        private readonly SocketAsyncEventArgs args;
        public Task<int> ReceiveAsync(byte[] buffer, int offset, int count)
        {
            
            TaskCompletionSource<int> source = new TaskCompletionSource<int>();
            try
            {
                args.SetBuffer(buffer, offset, count);
                args.UserToken = source;
                if (!socket.ReceiveAsync(args))
                {
                    if (ShouldSetResult(source, args))
                    {
                        return Task.FromResult(args.BytesTransferred);
                    }
                }
            }
            catch (Exception ex)
            {
                source.TrySetException(ex);
            }
            return source.Task;
        }
        static bool ShouldSetResult<T>(TaskCompletionSource<T> source, SocketAsyncEventArgs args)
        {
            if (args.SocketError == SocketError.Success) return true;
            var ex = new InvalidOperationException(args.SocketError.ToString());
            source.TrySetException(ex);
            return false;
        }
    }
