    interface ICameraController
    {
        void Pan();
        void Tilt();
        void Zoom();
    }
    class BrandACameraController: ICameraController
    {
        public BrandACameraController()
        {
        }
        public void Pan()
        {
            //interface with brand a camera
        }
        public void Tilt()
        {
            //interface with brand a camera
        }
        public void Zoom()
        {
            //interface with brand a camera
        }
    }
    class BrandBCameraController: ICameraController
    {
        public BrandBCameraController()
        {
        }
        public void Pan()
        {
            //interface with brand b camera
        }
        public void Tilt()
        {
            //interface with brand b camera
        }
        public void Zoom()
        {
            //interface with brand b camera
        }
    }
