    public abstract class CameraBase
    {
        public abstract void Start();
        public virtual string Name { get; protected set; }
    }
    public class CameraType1 : CameraBase
    {
        public CameraType1()
        {
            // Stuff specific to this type of camera
            Name = "Type 1";
        }
        public override void Start()
        {
            // Stuff specific to starting a stream to this type
        }
    }
    public class CameraType2 : CameraBase
    {
        public CameraType2()
        {
            // Stuff specific to this type of camera
            Name = "Type 2";
        }
        public override void Start()
        {
            // Stuff specific to starting a stream to this type
        }
    }
    public class Pane
    {
        CameraBase camera;
        public Pane(string CameraTypeToDeploy)
        {
            switch (CameraTypeToDeploy) {
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
            camera.Start();   //OK, all cameras have a Start() method
        }
    }
