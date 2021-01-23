    public class Linkable {
        public IList<ILink> links { get; set; }
        public void AddLink(ILink link) {
            if (links == null) {
                links = new List<ILink>();
            }
            links.Add(link);
        }
    }
