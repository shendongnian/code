    public class VendorSpecificCamera
    {
        public string Name { get; } 
        public bool VendorSpecificStart(int mode, int framesPerSecond)
    }
    public class CameraType1 : VendorSpecificCamera, ICamera
    {
        // The 'Name' property is already implemented in this example.
        public bool CameraStarted { get; private set }
        public void Start()
        {
            CameraStarted = VendorSpecificStart(2, 25);
        }
    }
