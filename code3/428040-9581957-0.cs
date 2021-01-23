    public class LanguageLinkProvider : LinkProvider
    {
        public override string GetItemUrl(Item item, UrlOptions urlOptions)
        {
            urlOptions.SiteResolving = Configuration.Settings.Rendering.SiteResolving;
            string sites = ConfigurationManager.AppSettings["EmbedLanguageInUrl"];
            var splitSites = new List<string>();
            if (!string.IsNullOrEmpty(sites))
                splitSites = sites.Split(';').ToList();
            if (splitSites.Contains(urlOptions.Site.Name))
                urlOptions.LanguageEmbedding = LanguageEmbedding.Always;
            else
                urlOptions.LanguageEmbedding = LanguageEmbedding.Never;
            return base.GetItemUrl(item, urlOptions);
        }
    }
