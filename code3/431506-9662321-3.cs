        private List<ImageViewModel> ConvertSmugMugModel(SmugMugModel smugMugGallery)
        {
            return smugMugGallery.Channel.Items.Select(i => new ImageViewModel
            {
                TinyImage = i.Group.Contents.Count() > 0 ? i.Group.Contents[0].Url:new Url("blank"),
                ThumbnailUrl = i.Group.Contents.Count() > 1 ? i.Group.Contents[1].Url:new Url("blank"),
                SmallImageUrl = i.Group.Contents.Count() > 2 ? i.Group.Contents[2].Url:new Url("blank"),
                MediumImageUrl = i.Group.Contents.Count() > 3 ? i.Group.Contents[3].Url:new Url("blank"),
                LargeImageUrl = i.Group.Contents.Count() > 4 ? i.Group.Contents[4].Url:new Url("blank")
            }).ToList();
        }
