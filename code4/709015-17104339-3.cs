    static class CameraControllerFactory
    {
        public static ICameraController Create(string brand)
        {
            if (brand == "A")
                return new BrandACameraController();
            else
                return new BrandBCameraController();
        }
    }
