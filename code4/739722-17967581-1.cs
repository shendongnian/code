    pic = (byte[])myPicutureFromDatabase;
    using (var fs = new BinaryWriter(new FileStream(filepath, FileMode.Create, FileAccess.Write)))
           {
              fs.Write(pic);
              fs.Flush();
              continue;
            }
