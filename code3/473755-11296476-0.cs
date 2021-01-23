    TagLib.File f = TagLib.Mpeg.File.Create(GetMPG.FileName);
    
    foreach(ICodec codec in f.Properties.Codecs){
      TagLib.Mpeg.VideoHeader G = (TagLib.Mpeg.VideoHeader) codec;
      if(G != null){
        MPGbps.Text = G.VideoFrameRate.ToString();
      }
    }
