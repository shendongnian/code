    public class MyMediaCrawler : Sitecore.Search.Crawlers.DatabaseCrawler
    {
        protected override void AddAllFields(Document document, Item item, bool versionSpecific)
        {
            MediaItem mediaItem = item;
            document.Add(CreateField(Sitecore.Search.BuiltinFields.Content, item.DisplayName, true, 1f));
            document.Add(CreateField("anc", String.Join(" ", item.Axes.GetAncestors().Select(a => a.ID.ToShortID())), true, 1f));
            document.Add(CreateField("filename", String.IsNullOrEmpty(mediaItem.Title) ? item.DisplayName : mediaItem.Title, false, 1f));
        }
    }
