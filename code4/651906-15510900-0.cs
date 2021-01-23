    public class AClass
    {
        public Bitmap image;
        public int i;
    }
    Bitmap bmp = (Bitmap)Bitmap.FromFile(@"......");
    var json = JsonConvert.SerializeObject(new AClass() { image = bmp, i = 666 }, 
                                           new ImageConverter());
    var aclass = JsonConvert.DeserializeObject<AClass>(json, new ImageConverter());
