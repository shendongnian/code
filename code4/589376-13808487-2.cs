    public Interface CameraType
    {
        void Start();
    }
    
    public class CameraType1 : ICameraType  //not to be used directly
    {
        public CameraType1()
        {
            Stuff specific to this type of camera
        }
    
        public void Start()
        {
            // Stuff specific to starting a stream to this type
        }
    }
    
    public class CameraType2 : ICameraType  //not to be used directly
    {
        public CameraType2()
        {
            // Stuff specific to this type of camera
        }
    
        public void Start()
        {
            // Stuff specific to starting a stream to this type
        }
    }
    
    public class Pane
    {
        ICameraType camera;
    
        public Pane(string CameraTypeToDeploy)
        {
            switch (CameraTypeToDeploy)
            {
                case "Type1":
                    camera = new CameraType1();
                    break;
                case "Type2":
                    camera = new CameraType2();
                    break;
            }
        }
    
        public void Start()
        {
            camera.Start(); 
        }
    }
