    private PostModel PostModelConverter(Post post)
    {
        Link link = post.Link;
        if (link == null)
        {
            throw new ArgumentException("post.Link can't be null");
        }
        if (link.Type == LinkType.Html)
        {
            var model = AutoMapper.Map<PostedLinkModel>(post);
            model.PostSlug = postService.GetTitleSlug(post);
            return model;
        }
        else if (link.Type == LinkType.Image)
        {
            var model = AutoMapper.Map<PostedImageModel>(post);
            model.PostSlug = postService.GetTitleSlug(post);
            return model;
        }
        return null;
    }
