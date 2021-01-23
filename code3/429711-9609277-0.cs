    static void Main()
    {
      var AsmPath =System.IO.Path.GetDirectoryName( 
        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase ) ;
     
       var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      if (AsmPath == desktopPath)
      (
          MessageBox.Show ("You can only run this from the desktop");
          Application.Exit();
      )
      else 
           Application.Run(new Form1());
    }
   
