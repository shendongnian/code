    interface ICFileStream
	{
		void Write(string s);
        FileStream GetStream(string filePath);
	}
    /// <summary>
    /// Just a silly example class
    /// </summary>
    class CFileStream: ICFileStream
    {
        protected readonly string FilePath;
        public CFileStream(string filePath)
        {
            FilePath = filePath;
        }
        public void Write(string s)
        {
            var stream = GetStream(FilePath);
            //etc
        }
        /// <summary>
        /// Take filePath as an argument to make subclassing easier
        /// </summary>
        protected FileStream GetStream(string filePath)
        {
            return new FileStream(filePath, FileMode.OpenOrCreate);
        }
    }
    /// <summary>
    /// Building on top of CFileStream, created an encrypted version
    /// </summary>
    class CFileStreamEncrypted : ICFileStream
    {
        private readonly string _key;
        private readonly ICFileStream _stream;
        public CFileStreamEncrypted(string key, ICFileStream stream)
        {
            _key = key;
            _stream = stream;
        }
        /// <summary>
        /// For added complexity, let's also wrap a possible excepton
        /// </summary>
        public void Write(string s)
        {
            try
            {
                _stream.Write(s);
            }
            catch (ImaginaryCryptoException ex)
            {
                throw new ImaginaryCustomException("bladibla", ex);
            }
        }
        /// <summary>
        /// Wrap the base stream in an imaginary crypto class
        /// </summary>
        protected FileStream GetStream(string filePath)
        {
            return new CImaginaryCryptoStream(_stream.GetStream(filePath), _key);
        }
    }
    class CFileStreamSplit : ICFileStream
    {
        private readonly ICFileStream _stream;
        public CFileStreamSplit(ICFileStream stream) 
        {
            _stream = stream;
        }
        protected int Counter;
        /// <summary>
        /// Close stream and move to next file at the appropriate time(s)
        /// </summary>
        public void Write(string s)
        {
            do
            {
                Stream stream;
                if (ImaginaryBooleanMustSplit)
                    stream = GetStream(FilePath);
                //etc
            } while (ImaginaryBooleanDataLeftToWrite);
        }
        /// <summary>
        /// Get base stream but with altered filePath
        /// </summary>
        protected FileStream GetStream(string filePath)
        {
            return _stream.GetStream(GetNextpath(filePath));
        }
        /// <summary>
        /// Ignore proper extension / file-exists etc.
        /// </summary>
        protected string GetNextpath(string filePath)
        {
            return filePath + ++Counter;
        }
    }
