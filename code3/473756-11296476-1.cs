    TagLib.File f = TagLib.Mpeg.File.Create(GetMPG.FileName);
    
    foreach(ICodec codec in f.Properties.Codecs){
      if(codec is TagLib.Mpeg.VideoHeader) {
        TagLib.Mpeg.VideoHeader G = (TagLib.Mpeg.VideoHeader) codec;
        MPGbps.Text = G.VideoFrameRate.ToString();
      }
    }
