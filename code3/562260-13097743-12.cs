    List<ControlGroup> setOfControls = new List<ControlGroup>();
    for(int i=0; i<10 ;i++)
    {
       ControlGroup cg1 = Page.LoadControl("~/ControlGroup.ascx") as ControlGroup;
       if(cg1 != null)
       {
         cg1.T1Tp1.Text = "";
         cg1.LBL.Text = "";
         cg1.TBX.Text = "";
         setOfControls.Add(cg1);
       }
    }
