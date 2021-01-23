    public async Task Send(ArraySegment<byte> buffer, CancellationToken cancellationToken)
    {
        using (await readerWriterLock.ReaderLockAsync())
        {
            if (!tcpClient.Connected)
                throw new InvalidOperationException("Can't send when not open");
            await sendStream.WriteAsync(buffer.Array, buffer.Offset, buffer.Count, cancellationToken);
        }
    }
