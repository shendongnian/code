    public sealed class AIPath
    {
        // TODO: Consider trying to make this immutable, or
        // at least not exposing the collections so widely. Exposing an array
        // property is almost always a bad idea.
        public List<Vector2> Waypoints { get; set; }
        public int LinkNumber { get; set; }
        public int[] PotentialLinks { get; set; }
        public XElement ToElement()
        {
            return new XElement("path",
                WayPoints.Select(v2 => new XElement("point",
                                           new XAttribute("X", (int) v2.X),
                                           new XAttribute("Y", (int) v2.Y))));
        }
        public static AIPath FromXElement(XElement path)
        {
            return new AIPath
            {
                WayPoints = path.Elements("point")
                                .Select(p => new Vector2((int) p.Attribute("X"),
                                                         (int) p.Attribute("Y")))
                                .ToList();
            };
        }
    }
