    foreach (string picture in SamePolicyPics)
    {
      if (frame == 0)
      {
        using (pages = (Bitmap)Image.FromFile(picture))
        {
          pages.Save(AppVars.FinalPolicyImagesDirectory + picture.Substring(29, 7)  + ".tiff", info, ep);
        }
      }
      else
      {
        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);
        using (Bitmap bm = (Bitmap)Image.FromFile(picture))
        {
          pages.SaveAdd(bm, ep);
        }
      }
    
      if (frame == SamePolicyPics.Length - 1)
      {
        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
        pages.SaveAdd(ep); // this is where it gets funky, you need to restructure
      }
      frame++;
    }
