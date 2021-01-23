    public class NoPadProblemSymmetricAlgorithm : SymmetricAlgorithm
    {
        private SymmetricAlgorithm m_Algo;
        public NoPadProblemSymmetricAlgorithm(SymmetricAlgorithm algo)
        {
            if (algo == null)
                throw new ArgumentNullException();
            m_Algo = algo;
        }
    
        public override ICryptoTransform  CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
        {
            if (m_Algo.Padding == PaddingMode.None)
                return new NoPaddingTransformWrapper(m_Algo.CreateDecryptor(rgbKey, rgbIV));
            else
                return m_Algo.CreateDecryptor(rgbKey, rgbIV);
        }
        public override ICryptoTransform  CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
        {
            if (m_Algo.Padding == PaddingMode.None)
                return new NoPaddingTransformWrapper(m_Algo.CreateEncryptor(rgbKey, rgbIV));
            else
                return m_Algo.CreateEncryptor(rgbKey, rgbIV);
        }
        #region simple wrap
        public override void  GenerateIV()
        {
            m_Algo.GenerateIV();
        }
        public override void  GenerateKey()
        {
            m_Algo.GenerateIV();
        }
        public override int BlockSize
        {
            get { return m_Algo.BlockSize; }
            set { m_Algo.BlockSize = value; }
        }
        public override int FeedbackSize
        {
            get { return m_Algo.FeedbackSize; }
            set { m_Algo.FeedbackSize = value; }
        }
        public override byte[] IV
        {
            get { return m_Algo.IV; }
            set { m_Algo.IV = value; }
        }
        public override byte[] Key
        {
            get { return m_Algo.Key; }
            set { m_Algo.Key = value; }
        }
        public override int KeySize
        {
            get { return m_Algo.KeySize; } 
            set { m_Algo.KeySize = value; }
        }
        public override KeySizes[] LegalBlockSizes
        {
            get { return m_Algo.LegalBlockSizes; }
        }
        public override KeySizes[] LegalKeySizes
        {
            get { return m_Algo.LegalKeySizes; }
        }
        public override CipherMode Mode
        {
            get { return m_Algo.Mode; }
            set { m_Algo.Mode = value; }
        }
        public override PaddingMode Padding
        {
            get { return m_Algo.Padding; }
            set { m_Algo.Padding = m_Algo.Padding; }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                m_Algo.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
