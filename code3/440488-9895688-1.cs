    public void TransformStream(Stream a_stream, long a_length = -1)
    {
        Debug.Assert((a_length == -1 || a_length > 0));
    
        if (a_stream.CanSeek)
        {
            if (a_length > -1)
            {
                if (a_stream.Position + a_length > a_stream.Length)
                    throw new IndexOutOfRangeException();
            }
    
            if (a_stream.Position >= a_stream.Length)
                return;
        }
    
        System.Collections.Concurrent.ConcurrentQueue<byte[]> queue =
            new System.Collections.Concurrent.ConcurrentQueue<byte[]>();
        System.Threading.AutoResetEvent data_ready = new System.Threading.AutoResetEvent(false);
        System.Threading.AutoResetEvent prepare_data = new System.Threading.AutoResetEvent(false);
    
        Task reader = Task.Factory.StartNew(() =>
        {
            long total = 0;
    
            for (; ; )
            {
                byte[] data = new byte[BUFFER_SIZE];
                int readed = a_stream.Read(data, 0, data.Length);
    
                if ((a_length == -1) && (readed != BUFFER_SIZE))
                    data = data.SubArray(0, readed);
                else if ((a_length != -1) && (total + readed >= a_length))
                    data = data.SubArray(0, (int)(a_length - total));
    
                total += data.Length;
    
                queue.Enqueue(data);
                data_ready.Set();
    
                if (a_length == -1)
                {
                    if (readed != BUFFER_SIZE)
                        break;
                }
                else if (a_length == total)
                    break;
                else if (readed != BUFFER_SIZE)
                    throw new EndOfStreamException();
    
                prepare_data.WaitOne();
            }
        });
    
        Task hasher = Task.Factory.StartNew((obj) =>
        {
            IHash h = (IHash)obj;
            long total = 0;
    
            for (; ; )
            {
                data_ready.WaitOne();
    
                byte[] data;
                queue.TryDequeue(out data);
    
                prepare_data.Set();
    
                total += data.Length;
    
                if ((a_length == -1) || (total < a_length))
                {
                    h.TransformBytes(data, 0, data.Length);
                }
                else
                {
                    int readed = data.Length;
                    readed = readed - (int)(total - a_length);
                    h.TransformBytes(data, 0, data.Length);
                }
    
                if (a_length == -1)
                {
                    if (data.Length != BUFFER_SIZE)
                        break;
                }
                else if (a_length == total)
                    break;
                else if (data.Length != BUFFER_SIZE)
                    throw new EndOfStreamException();
            }
        }, this);
    
        reader.Wait();
        hasher.Wait();
    }
