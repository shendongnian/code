using (Image img = System.Drawing.Image.FromStream(sourceStream))
{
  using (FileStream fileStream = System.IO.File.Create(filePath))
  {
    int pages = img.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
    if (pages == 1)
    {
      img.Save(fileStream, img.RawFormat); // if there is just one page, just save the file
    }
    else
    {
      var encoder = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders().First(x => x.MimeType == fileInfo.MediaType);
      var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
      encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, Convert.ToInt32(System.Drawing.Imaging.EncoderValue.MultiFrame));
      img.Save(fileStream, encoder, encoderParams); // save the first image with MultiFrame parameter
      for (int f = 1; f < pages; f++)
      {
        img.SelectActiveFrame(FrameDimension.Page, f); // select active page (System.Drawing.Image.FromStream loads the first one by default)
        encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, Convert.ToInt32(System.Drawing.Imaging.EncoderValue.FrameDimensionPage));
        img.SaveAdd(img, encoderParams); // save add with FrameDimensionPage parameter
      }
    }
  }
}
 - *sourceStream* is a System.IO.MemoryStream which holds the byte array of the file content
 - *filePath* is absolute path to cache directory (something like 'C:/Cache/multiframe.tiff')
 - *fileInfo* is a model holding the actual byte array, fileName, mediaType and other data
