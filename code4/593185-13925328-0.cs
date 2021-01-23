    int ix = 0;
    foreach( var dst in new [] { galleryImage.TinyImage, galleryImage.Thumbnail, etc }) {
      src = img.Group.Contents[ix];
      dst.Url = src.Url;
      dst.FileSize = src.FileSize;
      dst.Type = src.Type;
      dst.Medium = src.Medium;
      dst.Width = src.Width;
      dst.Height = src.Height;
      dst.Hash = src.Hash;
      ix++;
    }
