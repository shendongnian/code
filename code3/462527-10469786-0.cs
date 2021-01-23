    public void Album_Notes(HtmlAgilityPack.HtmlDocument bandHTML)
    {
        var div = bandHTML.DocumentNode.Descendants("div").First(x => x.Id == "album_notes");
        this.lblNotes.Text = div.InnerHtml;
    }
