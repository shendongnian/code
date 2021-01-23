    public static MvcHtmlString ContentRating(this HtmlHelper html, ContentKey contentKey)
    {
        ContentRatingModel contentRatingModel = new ContentRatingHelper().GetContentRatingModel(contentKey);
        var result = html.Partial("ContentRating", contentRatingModel);
        return new MvcHtmlString(result.ToHtmlString());
    }
