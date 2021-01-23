    protected override void Render(HtmlTextWriter writer)
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
        base.Render(writer);
    }
