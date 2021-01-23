    public class IndexCrawler : DatabaseCrawler
    {
        protected override void IndexVersion(Item item, Item latestVersion, Sitecore.Search.IndexUpdateContext context)
        {
            if (item.Versions.Count > 0 && item.Version.Number != latestVersion.Version.Number)
                return;
            base.IndexVersion(item, latestVersion, context);
        }
    }
