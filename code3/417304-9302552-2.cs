	using System.Linq; // Don't forget to add using statement for System.Linq
	public class RssReader
	{
		private List<IEnumerable<RSSItem>> _feeds = new List<IEnumerable<RSSItem>>();
		public void Download()
		{
			WebClient wc = new WebClient();
			wc.DownloadStringCompleted += this.FeedDownloaded;
			wc.DownloadStringAsync(new Uri("feed-goes-here"));
		}
		private void FeedDownloaded(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error != null) return;
			var xml = XElement.Parse(e.Result);
			var feed = from x in xml.Descendants("item")
					   where x.Element("enclosure") != null && x.Element("description") != null
					   select new RSSItem()
					   {
						   Date = DateTime.Parse(x.Element("date").Value),
						   Title = x.Element("title").Value,
						   ImageSource = x.Element("enclosure").FirstAttribute.Value
					   };
			_feeds.Add(feed);
			if (_feeds.Count == 2)
			{
				var result = this.Weave(_feeds[0], _feeds[1]);
				// Assign result to the list box's ItemSource
				// Or better, use data binding.
			}
		}
		/// <summary>
		/// Combines the two feeds, sorts them by date, and returns the ten most recent entries.
		/// </summary>
		private IEnumerable<RSSItem> Weave(IEnumerable<RSSItem> feed1, IEnumerable<RSSItem> feed2)
		{
			return feed1.Concat(feed2)
				.OrderByDescending(i => i.Date)
				.Take(10);
		}
	}
