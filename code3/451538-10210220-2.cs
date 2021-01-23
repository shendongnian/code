    public void Test() {
      DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
      foreach (var subDir in dir.GetDirectories()) {
        if (-1 < subDir.Name.ToLower().IndexOf("pictures")) {
          foreach (var file in subDir.GetFiles()) {
            byte[] data = GetFile(file.FullName);
            if (data != null) {
              Console.WriteLine(data.Length);
            }
          }
        }
      }
    }
    public byte[] GetFile(string filename) {
      byte[] result = null;
      try {
        if (File.Exists(filename)) {
          int len = 0;
          FileInfo file = new FileInfo(filename);
          byte[] data = new byte[file.Length];
          using (BinaryReader br = new BinaryReader(file.Open(FileMode.Open, FileAccess.Read))) {
            len = br.Read(data, 0, data.Length);
            br.Close();
          }
          if (0 < len) {
            if (len == data.Length) {
              return data;
            } else {
              // this section of code was never triggered in my tests;
              // however, it is good to keep it as a backup.
              byte[] dat2 = new byte[len];
              Array.Copy(data, dat2, len);
              return dat2;
            }
          }
        }
      } catch (IOException err) {
        // file is being used by another process.
      } catch (ObjectDisposedException err) {
        // I am guessing you would never see this because your binFile is not disposed
      }
      return result;
    }
