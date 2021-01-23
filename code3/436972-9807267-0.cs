     public void ExtractFileFromResources(String filename, String location)
            {
              //  Assembly assembly = Assembly.GetExecutingAssembly();
                System.Reflection.Assembly a =  System.Reflection.Assembly.GetExecutingAssembly();
                            Stream resFilestream = a.GetManifestResourceStream(filename);
                if (resFilestream != null)
                {
                     BinaryReader br = new BinaryReader(resFilestream);
                     FileStream fs = new FileStream(location, FileMode.Create); 
                     BinaryWriter bw = new BinaryWriter(fs);
                     byte[] ba = new byte[resFilestream.Length];
                    resFilestream.Read(ba, 0, ba.Length);
                  bw.Write(ba);
                br.Close();
                bw.Close();
                resFilestream.Close();
            }
          
        }
     string path = Path.Combine(System.IO.Path.GetTempPath() + "\file.html");
     ExtractFileFromResources("file.html", path);
     Process.Start(path);
