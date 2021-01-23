    /// <summary>
    /// A packet of data with some form of meta data which frames the payload for transport in via a stream.
    /// </summary>
    public interface IFramedData
    {
        /// <summary>
        /// Get the data payload from the framed data (excluding any bytes that are used to frame the data)
        /// i.e. The received data minus protocl specific framing
        /// </summary>
        public readonly byte[] Data { get; }
        /// <summary>
        /// Get the framed data (payload including framing bytes) ready to send
        /// </summary>
        /// <returns>Framed data</returns>
        public byte[] ToBytes();
    }
