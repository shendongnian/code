    class MyImageExportDllClass
    {
       [Export("MyExternalImage)]
       public Image MyImage {get; privtae set;}
       public MyImageExportDllClass()
       {
          this.MyImage = Image.FromFile("SampImag.jpg");
       }
    }
