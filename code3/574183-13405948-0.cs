        public Task<Server> PingAsync()
        {
            var tcs = new TaskCompletionSource<Server>();
            _ping.PingCompleted += (sender, e) =>
                {
                    tcs.TrySetResult(this);
                    if (e.Error == null)
                    {
                        Status = e.Reply.Status;
                    }                   
                };
            _ping.SendAsync(Address, new object());
            return tcs.Task;
        }
