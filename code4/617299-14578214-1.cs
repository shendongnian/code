    class DigitalCamera
    {
        static int currentPhotoNumber = 0;
        private Random rnd = new Random();
        public override void TakePhoto()
        {
            int photo = rnd.Next(1, 10);
            MemoryCard.buffer[currentPhotoNumber++] = photo;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        
            DigitalCamera digitalCamera = new DigitalCamera("kodak", 43, newMemoryCard, 3);
        
            digitalCamera.TakePhoto();
            digitalCamera.TakePhoto();
            digitalCamera.TakePhoto();
        
        }
    }
