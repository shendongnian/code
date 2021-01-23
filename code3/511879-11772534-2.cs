	static class PagesExtension {
		public static IEnumerable<Range> Pages(this Document doc) {
			int pageCount = doc.Range().Information[WdInformation.wdNumberOfPagesInDocument];
			int pageStart = 0;
			for (int currentPageIndex = 1; currentPageIndex <= pageCount; currentPageIndex++) {
				var page = doc.Range(
					pageStart
				);
				if (currentPageIndex < pageCount) {
					//page.GoTo returns a new Range object, leaving the page object unaffected
					page.End = page.GoTo(
						What: WdGoToItem.wdGoToPage,
						Which: WdGoToDirection.wdGoToAbsolute,
						Count: currentPageIndex+1
					).Start-1;
				} else {
					page.End = doc.Range().End;
				}
				pageStart = page.End + 1;
				yield return page;
			}
			yield break;
		}
	}
