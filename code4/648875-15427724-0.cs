    public interface ICamera
    {
        Vector3 Position { get; }
        Matrix View { get; }
        Matrix Projection { get; }
    
        void Update(float deltaTime);
        void Target(Vector3 targetPosition);
    }
    
    public class CameraService
    {
        public static ICamera ActiveCamera { get; private set; }
    
        public static void ActivateCamera(ICamera camera)
        {
            if (ActiveCamera != null)
                camera.Target(ActiveCamera.Target);
    
            ActiveCamera = camera;
        }
    
        public static Update(float deltaTime)
        {
            if (ActiveCamera != null)
                ActiveCamera.Update(deltaTime);
        }
    }
    
    public class BasicCamera: ICamera
    {
        public Vector3 Position { get; protected set; }
        public Matrix View { get; protected set; }
        public Matrix Projection { get; protected set; }
    
        public void Target(Vector3 targetPosition)
        {
            View = Matrix.CreateLookAt(Position, targetPosition, something something);
        }
    
        public BasicCamera(Vector3 position, Vector3 target)
        {
            //Set shit up
        }
    }
