    private int _slideIndexInDefaultView;
    private void ButtonNormalView_Click(object sender, RibbonControlEventArgs e)
		{
			// Default view
			Globals.AddIn.Application.Windows[1].ViewType = Microsoft.Office.Interop.PowerPoint.PpViewType.ppViewNormal;
			Globals.AddIn.Application.ActiveWindow.Presentation.Slides[_slideIndexInDefaultView].Select();
		}
		private void ButtonSlideMasterView_Click(object sender, RibbonControlEventArgs e)
		{
			// Slide master view
			_slideIndexInDefaultView = Globals.AddIn.Application.ActiveWindow.View.Slide.SlideIndex;
			Globals.AddIn.Application.Windows[1].ViewType = Microsoft.Office.Interop.PowerPoint.PpViewType.ppViewSlideMaster;
		}
