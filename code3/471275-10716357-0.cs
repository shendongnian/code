    var types = new[] {typeof(WebAdminPriceRanges), typeof(WebAdminRatingQuestions)};
    // this will return false if Page is e.g. a WebAdminBase
    var is1 = types.Any(t => t == Page.GetType());
    // while this will return true
    var is2 = Page is WebAdminPriceRanges || Page is WebAdminRatingQuestions;
