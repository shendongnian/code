        private List<ImageViewModel> ConvertSmugMugModel(SmugMugModel smugMugGallery)
        {
            return smugMugGallery.Channel.Items.Select(i => new ImageViewModel
            {
                TinyImage = i.Group.Contents[0].Url,
                ThumbnailUrl = i.Group.Contents[1].Url,
                SmallImageUrl = i.Group.Contents[2].Url,
                MediumImageUrl = i.Group.Contents[3].Url,
                LargeImageUrl = i.Group.Contents.Count() > 4 ? i.Group.Contents[4].Url:new Url("blank")
            }).ToList();
        }
