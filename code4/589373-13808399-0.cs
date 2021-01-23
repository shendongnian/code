      public interface ICamera
      {
          void Start();
      } 
      public class Camera1 : ICamera 
      { 
           // your existing implementation 
      }
      public class Camera2 : ICamera 
      { 
           // your existing implementation 
      }
     public class Pane
     {
         ICamera camera;
         public Pane(string CameraTypeToDeploy)
         {
            // Your existing code
         }
         }
         public void Start()
         {
             camera.Start();   //ok, ICamera has a start method
         }
     }
