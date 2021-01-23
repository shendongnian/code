       class Data { }
        public class DataStreamException : Exception
        {
            public DataStreamException(string message, Exception inner)
                : base(message, inner)
            {   }
        }
    
        abstract class DataStream
        {
            protected abstract Data ReadNextImpl();
            public Data ReadNext()
            {
                try
                {
                    return ReadNextImpl();
                }
                catch (Exception ex)
                {
                    throw new DataStreamException("Could not read from stream. See inner exception for details.", ex);
                }
            }
        }
    
        class DeserializingFileDataStream : DataStream
        {
            protected override Data ReadNextImpl()
            {
                throw new NotImplementedException();
            }
    
        }
    
        class NetworkDataStream : DataStream
        {
            protected override Data ReadNextImpl()
            {
                throw new Exception();
            }
        }
