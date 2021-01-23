    System.Reflection.Assembly thisExe;
    thisExe = System.Reflection.Assembly.GetExecutingAssembly();
    System.IO.Stream file = 
    thisExe.GetManifestResourceStream("AssemblyName.ImageFile.jpg");
    this.pictureBox1.Image = Image.FromStream(file);
