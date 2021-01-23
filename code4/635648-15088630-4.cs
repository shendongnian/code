    class MainDetails
    {
        string Attr1 { get; set; }
        string Attr2 { get; set; }
        protected virtual bool Matches(IEnumerator<string> e)
        {
            // Check the first two items exist and match
            return
                e.MoveNext() && e.Current.Equals(Attr1) &&
                e.MoveNext() && e.Current.Equals(Attr2);
        }
        public bool Matches(IEnumerable<string> details)
        {
            using (var e = details.GetEnumerator())
            {
                // Check the details match. (Optionally check
                // that there are no "extra" details.)
                return Matches(e); // && !e.MoveNext();
            }
        }
    }
    class Details : MainDetails
    {
        string Attr3 { get; set; }
        string Attr4 { get; set; }
        string Attr5 { get; set; }
        protected override bool Matches(IEnumerator<string> e)
        {
            // Check the MainDetails match, and the next three too.
            return base.Matches(e) &&
                e.MoveNext() && e.Current.Equals(Attr3) &&
                e.MoveNext() && e.Current.Equals(Attr4) &&
                e.MoveNext() && e.Current.Equals(Attr5);
        }
    }
    ...
    List<string> values = getValues();
    Details detailsData = getDetails();
    if (detailsData.Matches(values))
        return true;
