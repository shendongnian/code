    TemplateControls_Headline ctrl = (TemplateControls_Headline)LoadControl("~/Controls/TemplateHeadline.ascx");
    ctrl.ID = "MyCtrl_" + CMSSession.Current.AddedTemplateControls.Count;
    ctrl.Remove.Click += new EventHandler(RemoveItem_OnClick);
    MySession.Current.AddedTemplateControls.Add((Control)ctrl);
    PlaceHolder ph = accAddTemplates.FindControl("phAddTemplateControlsArea") as PlaceHolder;
    ph.Controls.Add(ctrl);
