    [ServiceContract]
    public interface IPictureService
    {
        [OperationContract]
        void ShowPicture(byte[] picture);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class PictureService : IPictureService
    {
        private readonly Action<Image> _showPicture;
       
        public PictureService(Action<Image> showPicture)
        {
            _showPicture = showPicture;
        }
        public void ShowPicture(byte[] picture)
        {
            using(var ms = new MemoryStream(picture))
            {
                _showPicture(Image.FromStream(ms));    
            }            
        }
    }
