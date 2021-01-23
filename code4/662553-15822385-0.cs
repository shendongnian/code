    public class SwapData
    {
        public const int BlockSize = 1024;
 
        private int HotCount {
            get;
            set;
        }
        private long Offset {
            get;
            set;
        }
        private byte[] Data {
            get;
            set;
        }
        private string FileName {
            get;
            set;
        }
    }
    public class SwapFile
    {
        private List<SwapData> _swapData;
        public string SwapFileName
        { get; set; }
        public byte[] ReadData(string fileName, long offset, int numBytes)
        {
            if (!Cached(fileName, offset))
            {
                return StoreCache(fileName, offset);
            } else return Cache(fileName, offset, numBytes);
        }
        private bool Cached(string fileName, long offset)
        {
            return _swapData.Any(z => z.FileName.ToLower().Equals(fileName.ToLower()) && z.Offset >= offset);
        }
        private byte[] StoreCache(string fileName, long offset)
        {
            using (var bw = new BinaryReader(File.Open(fileName, FileMode.Open))) 
            {
                bw.BaseStream.Seek(offset, SeekOrigin.Begin);
                var sd = new SwapData();
                sd.HotCount = 0;
                sd.Office = offset;
                sd.FileName = fileName;
                sd.Data = bw.ReadBytes(sd.BlockSize);
                _swapData.Add(sd);
                return sd.Data;
            }
        }
        private byte[] Cache(string fileName, long offset, int numBytes)
        {
            byte[] data = _swapData.FirstOrDefault(z => z.FileName.ToLower().Equals(fileName.ToLower()) && z.Offset >= offset).Data;
            byte[] target = new byte[numBytes];
            Array.Copy(data,target,numBytes);
            return target;
        }
