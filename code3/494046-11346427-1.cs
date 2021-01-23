    /// <summary>
    /// A protocol filter can be used to read and write data from/to a Stream and frame/deframe the messages.
    /// </summary>
    /// <typeparam name="TFramedData">The data frame that is handled by this filter</typeparam>
    public interface IProtocolFilter<TFramedData> where TFramedData : IFramedData
    {
        /// <summary>
        /// Should be raised whenever a complete data frame is ready to send.
        /// </summary>
        /// <remarks>
        /// May be raised after a call to <see cref="FlushSend()"/>
        /// </remarks>
        public event Action<TFramedData> DataToSend;
        /// <summary>
        /// Should be raised whenever a complete data frame has been received.
        /// </summary>
        /// <remarks>
        /// May be raised after a call to <see cref="FlushReceive()"/>
        /// </remarks>
        public event Action<TFramedData> DataReceived;
        /// <summary>
        /// Should be raised if any data written or read breaks the protocol.
        /// This could be due to any asynchronous operation that cannot be raised by the calling function.
        /// </summary>
        /// <remarks>
        /// Behaviour may be protocol specific such as flushing the read or write cache or even resetting the connection.
        /// </remarks>
        public event Action<Exception> ProtocolException;
        /// <summary>
        /// Read data into the recieve buffer
        /// </summary>
        /// <remarks>
        /// This may raise the DataReceived event (possibly more than once if multiple complete frames are read)
        /// </remarks>
        /// <param name="buffer">Data buffer</param>
        /// <param name="offset">Position within the buffer where data must start being read.</param>
        /// <param name="count">Number of bytes to read.</param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offset, int count);
        /// <summary>
        /// Write data to the send buffer.
        /// </summary>
        /// <remarks>
        /// This may raise the DataToSend event (possibly more than once if the protocl requires the data is broken into multiple frames)
        /// </remarks>
        /// <param name="buffer">Data buffer</param>
        /// <param name="offset">Position within the buffer where data must start being read.</param>
        /// <param name="count">Number of bytes to read from the buffer</param>
        public void Write(byte[] buffer, int offset, int count);
        /// <summary>
        /// Flush any data from the receive buffer and if appropriate, raise a DataReceived event.
        /// </summary>
        public void FlushReceive();
        /// <summary>
        /// Flush any data from the send buffer and if appropriate, raise a DataToSend event.
        /// </summary>
        public void FlushSend();
    }
