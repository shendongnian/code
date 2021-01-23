    if (e.Content != null && ContentReference.IsNullOrEmpty(e.Content.ContentLink))
    {
      var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
      var publishedVersionOfPage = contentLoader.Get<IContent>(e.Content.ContentLink);
    }
