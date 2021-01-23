    public class UploadUserFile
    {
        string _Token;
        string _UserId;
        string _IPAddress;
        string _DeviceInfo;
        string _FileName;
        string _ContentType;
        Stream _PhotoStream;
       public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }
        public string UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }
        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }
            set
            {
                _IPAddress = value;
            }
        }
        public string DeviceInfo
        {
            get
            {
                return _DeviceInfo;
            }
            set
            {
                _DeviceInfo = value;
            }
        }
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        public string ContentType
        {
            get
            {
                return _ContentType;
            }
            set
            {
                _ContentType = value;
            }
        }
        public Stream PhotoStream
        {
            get
            {
                return _PhotoStream;
            }
            set
            {
                PhotoStream = value;
            }
        }
        
    }
