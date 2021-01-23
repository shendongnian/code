    public class AesAlgorithm : AlgorithmItem
    {
        public AesAlgorithm()
        {
        }
        public override SymmetricAlgorithm Algorithm
        {
            get { return Aes.Create(); }
        }
        public override string DisplayName
        {
            get { return "AES"; }
        }
    }
    public class RijndaelAlgorithm : AlgorithmItem
    {
        public override SymmetricAlgorithm Algorithm
        {
            get { return Rijndael.Create(); }
        }
        public override string DisplayName
        {
            get { return "Rijndael"; }
        }
    }
    // ...
