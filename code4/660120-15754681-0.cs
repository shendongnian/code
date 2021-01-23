    public class Musician
    {
        private List<string> _hits;
        public string ListHits()
        {
            return string.Join(", ", _hits);
        }
        public void AddHit(string hit)
        {
            /*
             *  validate the hit
             */
            _hits.Add(hit);
        }
    }
