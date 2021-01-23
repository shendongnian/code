    public static class TcpStreamExtension
    {
        public static async Task<int> ReadAsyncWithTimeout(this NetworkStream stream, byte[] buffer, int offset, int count)
        {
            if (stream.CanRead)
            {
                Task<int> readTask = stream.ReadAsync(buffer, offset, count);
                Task delayTask = Task.Delay(stream.ReadTimeout);
                Task task = await Task.WhenAny(readTask, delayTask);
                if (task == readTask)
                        return await readTask;
            }
            return 0;
        }
    }
