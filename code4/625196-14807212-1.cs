    asm = System.Reflection.Assembly.Load(aName)
    string[] manifest = asm.GetManifestResourceNames();
    using (UnmanagedMemoryStream stream = (UnmanagedMemoryStream)asm.GetManifestResourceStream(manifest[0]))//The Index of the Image you want to use
    {
        using (MemoryStream ms1 = new MemoryStream())
        {
            stream.CopyTo(ms1);
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.StreamSource = new MemoryStream(ms1.ToArray());
            bmi.EndInit();
            image1.Source  = bmi; //The name of your Image Control
        }
                    
    }
