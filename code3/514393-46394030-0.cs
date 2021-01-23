    cfg.CreateMap<Post, PostModel>()
        .ConstructUsing(p =>
        {
            switch (p.Type)
            {
                case LinkType.Html: return new LinkPostModel
                {
                    Title = p.Description
                    // other specific fields
                };
                case LinkType.Image: return new ImagePostModel
                {
                    // other specific fields
                };
            }
            return null;
        })
        .ForMember(x => x.PostId, m => m.MapFrom(p => p.Id));
    cfg.CreateMap<PostList, PostListModel>();
