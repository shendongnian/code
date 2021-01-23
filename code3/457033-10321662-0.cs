    public class MyService : WebService {
        [SoapInclude(typeof(Bitmap))]
        public List<Image> GetImageList() {
            // code here
        }
    }
