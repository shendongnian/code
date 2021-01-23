        protected void lbAddHeadline_OnClick(object sender, EventArgs e)
        {
            Controls_Headline ctrl = (Controls_Headline)LoadControl("~/Controls/Headline.ascx");
            ctrl.ID = "MyCtrl_" + CMSSession.Current.AddedTemplateControls.Count;
            ctrl.Remove.CommandArgument = CMSSession.Current.AddedTemplateControls.Count.ToString();
            ctrl.Remove.Click += new EventHandler(RemoveItem_OnClick);
            
            CMSSession.Current.AddedTemplateControls.Add((Control)ctrl);
    
            LoadControlsToPanel();
        }
        protected override void OnInit(EventArgs e)
        {
            PlaceHolder ph = accAddTemplates.FindControl("phAddTemplateControlsArea") as PlaceHolder;
    
            int counter = 0;
    
            foreach (UserControl ctrl in CMSSession.Current.AddedTemplateControls)
            {
                ctrl.ID = "MyCtrl_" + counter;
                ITemplateControl ictrl = ctrl as ITemplateControl;
                ictrl.Remove.CommandArgument = counter.ToString();
                ictrl.Remove.Click += new EventHandler(RemoveItem_OnClick);
                counter++;
                ph.Controls.Add(ctrl);
            }
    
            base.OnInit(e);
        }
