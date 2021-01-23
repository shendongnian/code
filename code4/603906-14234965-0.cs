    public class EncodingWrapper : Encoding
    {
        private readonly Encoding innerEncoding;
        private readonly bool suppressPreamble;
        private static readonly byte[] EmptyBuffer = new byte[0];
        public EncodingWrapper(Encoding innerEncoding, bool suppressPreamble)
        {
            this.innerEncoding = innerEncoding;
            this.suppressPreamble = suppressPreamble;
        }
        public override byte[] GetPreamble()
        {
            return suppressPreamble ? EmptyBuffer : innerEncoding.GetPreamble();
        }
        public override int CodePage
        {
            get { return innerEncoding.CodePage; }
        }
        public override bool IsSingleByte
        {
            get { return innerEncoding.IsSingleByte; }
        }
        public override bool IsMailNewsSave
        {
            get { return innerEncoding.IsMailNewsSave; }
        }
        public override bool IsMailNewsDisplay
        {
            get { return innerEncoding.IsMailNewsDisplay; }
        }
        public override bool IsBrowserSave
        {
            get { return innerEncoding.IsBrowserSave; }
        }
        public override bool IsBrowserDisplay
        {
            get { return innerEncoding.IsBrowserDisplay; }
        }
        public override int WindowsCodePage
        {
            get { return innerEncoding.WindowsCodePage; }
        }
        public override string WebName
        {
            get { return innerEncoding.WebName; }
        }
        public override string HeaderName
        {
            get { return innerEncoding.HeaderName; }
        }
        public override string EncodingName
        {
            get { return innerEncoding.EncodingName; }
        }
        public override string BodyName
        {
            get { return innerEncoding.BodyName; }
        }
        public override string GetString(byte[] bytes, int index, int count)
        {
            return innerEncoding.GetString(bytes, index, count);
        }
        public override string GetString(byte[] bytes)
        {
            return innerEncoding.GetString(bytes);
        }
        public override int GetMaxCharCount(int byteCount)
        {
            return innerEncoding.GetMaxCharCount(byteCount);
        }
        public override int GetMaxByteCount(int charCount)
        {
            return innerEncoding.GetMaxByteCount(charCount);
        }
        public override Encoder GetEncoder()
        {
            return innerEncoding.GetEncoder();
        }
        public override Decoder GetDecoder()
        {
            return innerEncoding.GetDecoder();
        }
        public override bool IsAlwaysNormalized(NormalizationForm form)
        {
            return innerEncoding.IsAlwaysNormalized(form);
        }
        //public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
        //{
        //    return innerEncoding.GetChars(bytes, byteCount, chars, charCount);
        //}
        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
        {
            return innerEncoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
        }
        public override char[] GetChars(byte[] bytes, int index, int count)
        {
            return innerEncoding.GetChars(bytes, index, count);
        }
        public override char[] GetChars(byte[] bytes)
        {
            return innerEncoding.GetChars(bytes);
        }
        //public override int GetCharCount(byte* bytes, int count)
        //{
        //    return innerEncoding.GetCharCount(bytes, count);
        //}
        public override object Clone()
        {
            return new EncodingWrapper((Encoding)innerEncoding.Clone(), suppressPreamble);
        }
        public override int GetByteCount(string s)
        {
            return innerEncoding.GetByteCount(s);
        }
        public override int GetByteCount(char[] chars)
        {
            return innerEncoding.GetByteCount(chars);
        }
        public override int GetByteCount(char[] chars, int index, int count)
        {
            return innerEncoding.GetByteCount(chars, index, count);
        }
        //public override int GetByteCount(char* chars, int count)
        //{
        //    return innerEncoding.GetByteCount(chars, count);
        //}
        public override byte[] GetBytes(char[] chars)
        {
            return innerEncoding.GetBytes(chars);
        }
        public override byte[] GetBytes(char[] chars, int index, int count)
        {
            return innerEncoding.GetBytes(chars, index, count);
        }
        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return innerEncoding.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
        }
        public override byte[] GetBytes(string s)
        {
            return innerEncoding.GetBytes(s);
        }
        public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
        {
            return innerEncoding.GetBytes(s, charIndex, charCount, bytes, byteIndex);
        }
        //public override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
        //{
        //    return innerEncoding.GetBytes(chars, charCount, bytes, byteCount);
        //}
        public override int GetCharCount(byte[] bytes)
        {
            return innerEncoding.GetCharCount(bytes);
        }
        public override int GetCharCount(byte[] bytes, int index, int count)
        {
            return innerEncoding.GetCharCount(bytes, index, count);
        }
    }
