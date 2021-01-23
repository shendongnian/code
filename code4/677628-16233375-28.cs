    public void ReadIntoQueue<T>(FileStream fs, BlockingCollection<T[]> queue, int blockSize) where T: struct
    {
        while (true)
        {
            var data = FastRead<T>(fs, blockSize);
            if (data.Length == 0)
            {
                queue.CompleteAdding();
                break;
            }
            queue.Add(data);
        }
    }
