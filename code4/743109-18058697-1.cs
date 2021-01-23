    BinaryWriter writer = new BinaryWriter(netStream);
    while (someCondition) {
      // get the image
      Image img = SomeImage();
      // save the image to a MemoryStream
      MemoryStream ms = new MemoryStream();
      img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
      // get the image buffer
      byte[] buffer = new byte[ms.Length];
      ms.Seek(0, SeekOrigin.Begin);
      ms.Read(buffer, 0, buffer.Length);
      // write the size of the image buffer
      writer.Write(buffer.Length);
      // write the actual buffer
      writer.Write(buffer);
    }
