     public class BadFileStream : FileStream
            {
                public BadFileStream(string path, FileMode mode) : base(path, mode)
                {
                }
    
                public override bool CanWrite
                {
                    get
                    {
                        return false;
                    }
                }
    
                public override bool CanRead
                {
                    get
                    {
                        return false;
                    }
                }
            }
