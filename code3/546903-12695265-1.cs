    [ChildActionOnly]
    public ActionResult Commenting(string contentTypeName, int contentTypeId, int contentId)
    {
        //psuedo-code to get comments
        var comments = CommentingAPI.GetCommentsForContentType(contentTypeId, contentId);
    
        var viewModel = new CommentsListing
        {
            Comments = comments,
            ContentId = contentId,
            ContentTypeId = contentTypeId,
            ContentTypeName = contentTypeName
        };
        return View(viewModel);
    }
