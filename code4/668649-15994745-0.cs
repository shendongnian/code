    public class Ftp : IFtp
    {
        //other methods, properties and fields
        public void Dispose()
        {
            _ftp.Dispose();    
        }
    }
