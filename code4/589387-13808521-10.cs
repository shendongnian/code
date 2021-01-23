    public class CameraType1 : ICamera
    {
        private VendorSpecificCamera _camera;
        public CameraType1()
        {
            _camera = new VendorSpecificCamera();
        }
        public string Name { get { return _camera.Name; } } 
        public bool CameraStarted { get; private set; }
        public void Start()
        {
            CameraStarted = _camera.VendorSpecificStart(2, 25);
        }
    }
