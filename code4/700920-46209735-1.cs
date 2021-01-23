    public class GetWholeBodyPseudoHash : HashAlgorithm
    {
        protected override void Dispose(bool disposing)
        {
            if(disposing) _memoryStream.Dispose();
            base.Dispose(disposing);
        }
    
        static GetWholeBodyPseudoHash()
        {
            CryptoConfig.AddAlgorithm(typeof(GetWholeBodyPseudoHash), typeof(GetWholeBodyPseudoHash).FullName);
        }
    
        private MemoryStream _memoryStream=new MemoryStream();
        public override void Initialize()
        {
            _memoryStream.Dispose();
            _memoryStream = new MemoryStream();
        }
    
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            _memoryStream.Write(array, ibStart, cbSize);
        }
    
        protected override byte[] HashFinal()
        {
            return _memoryStream.ToArray();
        }
    }
    
    ...
    var bytes = new Hash(yourAssembly).GenerateHash(new GetWholeBodyPseudoHash());
