        gplus.HRef = "https://plusone.google.com/_/+1/confirm?title=" + HttpUtility.UrlEncode(Page.Title) + "&amp;url=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
        facebook.HRef = "http://www.facebook.com/sharer.php?t=" + HttpUtility.UrlEncode(Page.Title) + "&amp;u=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
        linkedin.HRef = "http://www.linkedin.com/shareArticle?mini=true&amp;title=" + HttpUtility.UrlEncode(Page.Title) + "&amp;url=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
        myspace.HRef = "http://www.myspace.com/Modules/PostTo/Pages/?t=" + HttpUtility.UrlEncode(Page.Title) + "&amp;u=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
        twitter.HRef = "http://twitter.com/share?text=" + HttpUtility.UrlEncode(Page.Title) + "&amp;url=" + HttpUtility.UrlEncode(Request.Url.AbsoluteUri);
