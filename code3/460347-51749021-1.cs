    string fileName = "test.pdf";
    System.Reflection.Assembly a = 
    System.Reflection.Assembly.GetExecutingAssembly();
            string fileName = a.GetName().Name + "." + 
    "test.pdf";
            using (Stream resFilestream = 
     a.GetManifestResourceStream(fileName))
            {
                if (resFilestream == null) return null;
                byte[] ba = new 
    byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                var byteArray= ba;
            }
