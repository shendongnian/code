	public void UpdateChildPagesReWrittenUrl(int parentPageId)
	{
		Func<PcPage, string> url = item => String.Format("{0}/{1}",
			GetRootUrl(item.ParentID), hnUrlHelper.UrlSafe(item.PageName));
					
		Array.ForEach(db.PcPages.Where(m => m.ParentID == parentPageId).ToArray(),
			x => { x.Url = url(x); });
		
		db.SaveChanges();
	}
