    protected override void OnInit(EventArgs e)
    {
        PlaceHolder ph = accAddTemplates.FindControl("phAddTemplateControlsArea") as PlaceHolder;
        int counter = 0;
        foreach (UserControl ctrl in MySession.Current.AddedTemplateControls)
        {
            ctrl.ID = "MyCtrl_" + counter;
            ctrl.Remove.CommandArgument = counter.ToString();
            ctrl.Remove.Click += new EventHandler(RemoveItem_OnClick);
            counter++;
            ph.Controls.Add(ctrl);
        }
        base.OnInit(e);
    }
