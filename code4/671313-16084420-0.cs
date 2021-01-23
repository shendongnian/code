     AVIReader reader = new AVIReader();
     List<Bitmap> ImagemMain = new List<byte[]>();
     reader.Open(_rootPath + Path.GetFileName(_arqs[0]));
     while (reader.Position - reader.Start < reader.Length)
     {
            using (var aux = reader.GetNextFrame())
            {
                 using (var r = new Bitmap(640, 480))
                 {
                       using (var g = Graphics.FromImage(r))
                       {                                               
                           g.DrawImage(aux, new Rectangle(0, 0, aux.Width, aux.Height));                                                   
                           ImagemMain.Add((Bitmap)r.Clone());
                       }
                                               
                 }
             }
      }
