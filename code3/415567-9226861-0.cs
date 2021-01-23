    public static class Extensions
    {
        public static void CleanNil(this XElement value)
        {
            value.DescendantsAndSelf().Where(x => x.Attribute("nil") != null && x.Attribute("nil").Value == "true").Remove();
        }
    }
