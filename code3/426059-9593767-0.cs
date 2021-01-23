     private int Add(ImageList.Original original, ImageList.ImageCollection.ImageInfo imageInfo)
      {
        if (original == null || original.image == null)
          throw new ArgumentNullException("value");
        int num = -1;
        if (original.image is Bitmap)
        {
          if (this.owner.originals != null)
            num = this.owner.originals.Add((object) original);
          if (this.owner.HandleCreated)
          {
            bool ownsBitmap = false;
            Bitmap bitmap = this.owner.CreateBitmap(original, out ownsBitmap);
            num = this.owner.AddToHandle(original, bitmap);
            if (ownsBitmap)
              bitmap.Dispose();
          }
        }
        else
        {
          if (!(original.image is Icon))
            throw new ArgumentException(System.Windows.Forms.SR.GetString("ImageListBitmap"));
          if (this.owner.originals != null)
            num = this.owner.originals.Add((object) original);
          if (this.owner.HandleCreated)
            num = this.owner.AddIconToHandle(original, (Icon) original.image);
        }
        if ((original.options & ImageList.OriginalOptions.ImageStrip) != ImageList.OriginalOptions.Default)
        {
          for (int index = 0; index < original.nImages; ++index)
            this.imageInfoCollection.Add((object) new ImageList.ImageCollection.ImageInfo());
        }
        else
        {
          if (imageInfo == null)
            imageInfo = new ImageList.ImageCollection.ImageInfo();
          this.imageInfoCollection.Add((object) imageInfo);
        }
        if (!this.owner.inAddRange)
          this.owner.OnChangeHandle(new EventArgs());
        return num;
      }
