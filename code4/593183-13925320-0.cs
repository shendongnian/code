    void ConfigureImage(MyImageType img, int pos) {
        img.Url = img.Group.Contents[pos].Url;
        img.FileSize = img.Group.Contents[pos].FileSize;
        img.Type = img.Group.Contents[pos].Type;
        img.Medium = img.Group.Contents[pos].Medium;
        img.Width = img.Group.Contents[pos].Width;
        img.Height = img.Group.Contents[pos].Height;
        img.Hash = img.Group.Contents[pos].Hash;
    }
