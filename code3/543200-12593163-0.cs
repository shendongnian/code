     public class MyObject
     {
       static ExtDeviceDriver devDrv;
      static MyObject()
      {
        devDrv = new ExtDeviceDriver();
      }
      public void Connect()
      {
        devDrv.connect();   
      }
     }
