	public void ReplaceBookmarkTextWithHtml(Bookmark bookmark, string html)
	{
		if (html != null) {
			Clipboard.SetData(DataFormats.Html, ClipboardFormatter.Html(html));
			bookmark.Range.PasteSpecial(DataType: WdPasteDataType.wdPasteHTML);
		}
	}
