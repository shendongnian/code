    abstract class CameraController
    {
        public abstract void Pan();
        public abstract void Tilt();
        public abstract void Zoom();
    }
    class BrandACameraController : CameraController
    {      
        public override void Pan()
        {
            //interface with brand a camera
        }
        public override void Tilt()
        {
            //interface with brand a camera
        }
        public override void Zoom()
        {
            //interface with brand a camera
        }
    }
    class BrandBCameraController : CameraController
    {      
        public override void Pan()
        {
            //interface with brand b camera
        }
        public override void Tilt()
        {
            //interface with brand b camera
        }
        public override void Zoom()
        {
            //interface with brand b camera
        }
    }
