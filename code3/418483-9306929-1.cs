    public void Insert (string filename)
    {
         var classLib = System.Reflection.Assembly.Load("MyClassLibrary.dll");
         var type = classLib.GetType("MyClassLibrary.Uploader"); //FULL NAME with namespace.;
         IUploader uploader = Activator.CreateInstance(type) as IUploader;
         
         uploader.Upload(filename);
    }
