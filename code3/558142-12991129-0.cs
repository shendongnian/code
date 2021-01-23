    public class PhotoExif
    {
        [Key]
        public int PhotoExifID { get; set; }
        public string ShutterSpeed { get; set; }
        //...
        [ForeignKey("PhotoExifID")]
        public virtual Photo Photo { get; set; }
    }
