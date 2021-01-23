    class Search
    {
        public static IEnumerable<XObject> PerformSearch(string xmlData, Models.SearchVars vars)
        {
            XDocument document = XDocument.Parse(xmlData);
            IEnumerable<XObject> result = document.Descendants(vars.ObjectType);
            if (! string.IsNullOrEmpty(vars.ClientId))
            {
                result = from i in result
                         where i.ToString().Contains(string.Format("ClientId={0}",vars.ClientId))
                         select i;
            }
            if (!string.IsNullOrEmpty(vars.CustRef))
            {
                result = from i in result
                         where i.ToString().Contains(string.Format("CustRef={0}", vars.CustRef))
                         select i;
            }
            return result;
        }
    }
