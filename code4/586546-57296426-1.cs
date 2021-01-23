	// ... some Word VSTO Addin code that calls SetView 
	
	Word.WdSeekView enumSavedSeekView = Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView;
	bool viewResetNeeded = SetView(workingStoryRange);
	if (viewResetNeeded)
	{
		Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView = enumSavedSeekView;
	}
	
	// ... end of some Word VSTO Addin code that calls SetView 
	private bool SetView(Word.Range range)
	{
		bool viewResetNeeded = false;
		// wdNormalView == Draft View, where SeekView can't be used and isn't needed.
		if (Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.Type != Word.WdViewType.wdNormalView)
		{
			// -1 Not Header/Footer, 0 Even page header, 1 Odd page header, 4 First page header
			// 2 Even page footer, 3 Odd page footer, 5 First page footer
			switch (range.Information[Word.WdInformation.wdHeaderFooterType])
			{
				case 0:
				case 1:
				case 4:
					if ((Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView != Word.WdSeekView.wdSeekEvenPagesHeader) && (Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView != Word.WdSeekView.wdSeekFirstPageHeader) && (Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView != Word.WdSeekView.wdSeekPrimaryHeader))
					{
						Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
						viewResetNeeded = true;
					}
					break;
				case 2:
				case 3:
				case 5:
					if ((Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView != Word.WdSeekView.wdSeekEvenPagesFooter) && (Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView != Word.WdSeekView.wdSeekFirstPageFooter) && (Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView != Word.WdSeekView.wdSeekPrimaryFooter))
					{
						Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
						viewResetNeeded = true;
					}
					break;
				default:
					break;
			}
		}
		return viewResetNeeded;
