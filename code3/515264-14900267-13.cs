    private HtmlHead originalPageHeader;
    static readonly Regex HeadStartRegex = new Regex(@"^\s*<head[^>]*>");
    static readonly Regex HeadEndRegex = new Regex(@"</head>\s*$");
    static readonly Regex TitleRegex = new Regex(@"<title>[^<]*</title>");
    public Default() { Init += Default_Init; }
    private void Default_Init(object sender, EventArgs e) { DoScraping(); }
    protected override void Render(HtmlTextWriter writer)
    {
        // get content from html head control generated via Page.Header:
        string headHtml = RenderControl(originalPageHeader);
        Controls.Remove(originalPageHeader);
        headHtml = HeadStartRegex.Replace(headHtml, string.Empty);
        headHtml = HeadEndRegex.Replace(headHtml, string.Empty);
        headHtml = TitleRegex.Replace(headHtml, string.Empty);
        // head.Controls.Add(new LiteralControl(headHtml)); doesnt work if head content placeholder contains code blocks (i.e. <% ... %>)
        // Instead add content this way:
        int headIndex = Controls.IndexOf(HeadContentPlaceHolder);
        if (headIndex != -1)
            Controls.AddAt(headIndex + 1, new LiteralControl(headHtml));
        base.Render(writer);
    }
    private void DoScraping()
    {
        IList<PagePart> parts = ... // do your scraping and splitting into parts
        Controls.Clear();
            
        foreach (PagePart part in parts)
        {
            var literalPart = part as LiteralPart;
            if (literalPart != null)
            {
                Controls.Add(new LiteralControl(literalPart.Text));
            }
            else
            {
                var placeHolderPart = part as PlaceHolderPart;
                switch (placeHolderPart.Type)
                {
                    case PlaceHolderType.Title:
                        Controls.Add(new LiteralControl(HttpUtility.HtmlEncode(Page.Title)));
                        break;
                    case PlaceHolderType.Head:
                        Controls.Add(HeadPlaceHolder);
                        Controls.Add(HeadContentPlaceHolder);
                        break;
                    case PlaceHolderType.Main:
                        Controls.Add(new LiteralControl("<div class='boxContent'>"));
                        Controls.Add(MainContentPlaceHolder);
                        Controls.Add(new LiteralControl("<div/>"));
                        break;
                }
            }
        }
    }
    private string RenderControl(Control control)
    {
        string innerHtml;
        using (var stringWriter = new StringWriter())
        {
            using (var writer = new HtmlTextWriter(stringWriter))
            {
                control.RenderControl(writer);
                writer.Flush();
                innerHtml = stringWriter.ToString();
            }
        }
        return innerHtml;
    }
