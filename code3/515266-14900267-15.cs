    class PlaceHolderInfo
    {
        public PlaceHolderInfo(PlaceHolderType type, Regex splitter)
        {
            Type = type;
            Splitter = splitter;
        }
        public PlaceHolderType Type { get; private set; }
        public Regex Splitter { get; private set; }
    }
    private static readonly List<PlaceHolderInfo> PlaceHolderInfos = new List<PlaceHolderInfo>
        {
            new PlaceHolderInfo(PlaceHolderType.Title, new Regex(TitleString)),
            new PlaceHolderInfo(PlaceHolderType.Head, new Regex(HeadString)),
            new PlaceHolderInfo(PlaceHolderType.Main, new Regex(MainString)),
        };
    private static List<PagePart> SplitPage(string html)
    {
        var parts = new List<PagePart>(new PagePart[] { new LiteralPart(html) });
        foreach (PlaceHolderInfo info in placeHolderInfos)
        {
            var newParts = new List<PagePart>();
            foreach (PagePart part in parts)
            {
                if (part is PlaceHolderPart)
                {
                    newParts.Add(part);
                }
                else
                {
                    var literalPart = (LiteralPart)part;
                    // Note about Regex.Split: if match is found in beginning or end of string, an empty string is returned in corresponding end of returned array.
                    string[] split = info.Splitter.Split(literalPart.Text); 
                    for (int i = 0; i < split.Length; i++)
                    {
                        newParts.Add(new LiteralPart(split[i]));
                        if (i + 1 < split.Length) // If result of Split returned more than one string, it means there was a match and we insert the placeholder between each string
                            newParts.Add(new PlaceHolderPart(info.Type));
                    }
                }
            }
            parts = newParts;
        }
        return parts;
    }
