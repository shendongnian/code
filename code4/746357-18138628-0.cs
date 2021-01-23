    await Task.Run(() =>
      {
          var fmt = Path.Combine(path, Path.GetFileNameWithoutExtension(fileName)) + "_modified{0}" + Path.GetExtension(fileName);
          int counter = 1;
          string newName;
          do {
              newName = string.Format(fmt, counter++);
          }
          while (File.Exists(newName));
          using (bitmap)
              bitmap.Save(newName);
      });
