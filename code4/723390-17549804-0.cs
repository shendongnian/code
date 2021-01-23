    using (var queue = new ProducerConsumerQueue<byte[]>(HandlerDelegate))
    {
        Parallel.ForEach(documents, document =>
        {
            using (var documentStream = new MemoryStream())
            {
                // saving document here ...
                queue.EnqueueTask(documentStream.ToArray());
            }
        });
    }
    protected void HandlerDelegate(byte[] content)
    {
        ZipOutputStream.PutNextEntry(Guid.NewGuid() + ".pdf");
    
        using (var stream = new MemoryStream(content))
        {
            stream.Position = 0; stream.CopyTo(ZipOutputStream);
        }
    }
