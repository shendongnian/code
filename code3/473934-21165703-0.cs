	/// <summary>
	/// AEG : Very important to handle the thread aborted exception
	/// </summary>
	/// <param name="w"></param>
	override protected void Render(HtmlTextWriter w)
	{
	    if (!isFileDownLoad) base.Render(w);
	} 
