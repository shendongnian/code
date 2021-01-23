    public static class MicrosoftStreamExtensions
    {
        public static IRandomAccessStream AsRandomAccessStream(this Stream stream) {
        return new RandomStream(stream);
    }
    }
    class RandomStream : IRandomAccessStream
    {
        Stream internstream;
        public RandomStream(Stream underlyingstream)
        {
            internstream = underlyingstream;
        }
        public IInputStream GetInputStreamAt(ulong position)
        {
            //THANKS Microsoft! This is GREATLY appreciated!
            internstream.Position = (long)position;
            return internstream.AsInputStream();
        }
        public IOutputStream GetOutputStreamAt(ulong position)
        {
            internstream.Position = (long)position;
            return internstream.AsOutputStream();
        }
        public ulong Size
        {
            get
            {
                return (ulong)internstream.Length;
            }
            set
            {
                internstream.SetLength((long)value);
            }
        }
    }
