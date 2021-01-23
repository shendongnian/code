    var imgType = new[] {
        galleryImage.TinyImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.Thumbnail = new SmugMugGalleryModel.Image._Img(),
        galleryImage.SmallImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.MediumImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.LargeImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.ExtraLargeImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.TwoExtraLargeImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.ThreeExtraLargeImage = new SmugMugGalleryModel.Image._Img(),
        galleryImage.OriginalImage = new SmugMugGalleryModel.Image._Img(),
    };
    
    var count = 0;
    foreach (var i in img.Group.Contents)
    {
        imgType[count].Url = i.Url;
        imgType[count].FileSize = i.FileSize;
        imgType[count].Type = i.Type;
        imgType[count].Medium = i.Medium;
        imgType[count].Width = i.Width;
        imgType[count].Height = i.Height;
        imgType[count].Hash = i.Hash;
        count++;
    }
