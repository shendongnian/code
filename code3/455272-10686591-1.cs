        public string GetPageUrl(Guid pageId, CultureInfo locale)
        {
            var pageUrlData = new PageUrlData(pageId, PublicationScope.Published, locale);
            return PageUrls.BuildUrl(pageUrlData, UrlKind.Public, new UrlSpace());
        }
