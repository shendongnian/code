    public void ScreenCapture()
    {
       var documentsDirectory = Environment.GetFolderPath
                                      (Environment.SpecialFolder.Personal);
    
       Console.WriteLine("start capture of frame: " + this.View.Frame.Size);
       UIGraphics.BeginImageContext(View.Frame.Size); 
       var ctx = UIGraphics.GetCurrentContext();
       if (ctx != null)
       {
          View.Layer.RenderInContext(ctx);
          UIImage img = UIGraphics.GetImageFromCurrentImageContext();
          UIGraphics.EndImageContext();
      
          // Set to display in a UIImage control _on_ the view
          imageLogo.Image = img;
      
          // Save to Photos
          img.SaveToPhotosAlbum(
             (sender, args)=>{Console.WriteLine("image saved to Photos");}
          );
      
          // Save to application's Documents folder
          string png = Path.Combine (documentsDirectory, "Screenshot.png");
          // HACK: overwrite the splash screen. iSOFlair is the application name
          //string png = Path.Combine (documentsDirectory, "../iSOFlair.app/Default.png");
          NSData imgData = img.AsPNG();
          NSError err = null;
          if (imgData.Save(png, false, out err))
          {
             Console.WriteLine("saved as " + png);
          } else {
             Console.WriteLine("NOT saved as" + png + 
                                " because" + err.LocalizedDescription);
          }
       }
       else
       {
          Console.WriteLine("ctx null - doesn't seem to happen");
       }
    }
