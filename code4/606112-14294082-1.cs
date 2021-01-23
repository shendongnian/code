    public class MainPageViewModel
    {
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            WebClient client = new WebClient();
            // HACK: Don't have access to the implementation to FXNewsAlert...
            //string xmlDoc = await FXNewsAlert.Misc.Extensions.DownloadStringTask(
            //    client, new Uri("http://www.forexfactory.com/ffcal_week_this.xml")); //breakpoint here
            string xmlDoc = await client.DownloadStringTaskAsync(
                new Uri("http://www.forexfactory.com/ffcal_week_this.xml")); //breakpoint here
            var events = XDocument.Parse(xmlDoc)
                .Descendants("event")
                .Select(n => new Event
                {
                    Title = n.Element("title").Value,
                    Country = n.Element("country").Value,
                    DateTime = DateTime.Parse(String.Format("{0} {1}", n.Element("date").Value, n.Element("time").Value)),
                    Impact = n.Element("forecast").Value,
                    Forecast = n.Element("forecast").Value,
                    Previous = n.Element("previous").Value
                }).ToList();
            return events;
        }
    }
