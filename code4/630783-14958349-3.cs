    public class Foto
    {
        public int Id { get; set; }
        public int ContentLength { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public virtual FotoBinary Content { get; set; }
    }
    
    public class FotoBinary
    {
        public int Id { get; set; }
        public virtual Foto Owner { get; set; }
        public byte[] Value { get; set; }
    }
