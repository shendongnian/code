    public class AesAlgorithm : IAlgorithmItem
    {
        public AesAlgorithm()
        {
        }
        public SymmetricAlgorithm CreateAlgorithm()
        {
            return Aes.Create();
        }
        public string DisplayName
        {
            get { return "AES"; }
        }
    }
    public class RijndaelAlgorithm : IAlgorithmItem
    {
        public SymmetricAlgorithm CreateAlgorithm()
        {
            return Rijndael.Create(); 
        }
        public string DisplayName
        {
            get { return "Rijndael"; }
        }
    }
    // ...
