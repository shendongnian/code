    private Control _contentControl;
    _contentControl = Page.LoadControl("~/Administration/Projects/UserControls/" + controlName);
			((IEditProjectControl)_contentControl).ProjectId = ProjectId;
			plhContent.Controls.Clear();
			plhContent.Controls.Add( _contentControl );
			_contentControl.ID = "ctlContent";
            Image2.Visible = ((IEditProjectControl)_contentControl).ShowSaveButton;
            SaveButton.Visible = ((IEditProjectControl)_contentControl).ShowSaveButton;
            ((IEditProjectControl)_contentControl).Initialize();
    
