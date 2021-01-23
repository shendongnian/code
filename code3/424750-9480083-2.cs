    {
      MyUserControl control = Page.LoadControl("~/path_to_my_usercontrol");
      control.ID = "MyUserControl1";
      DynamicControlCount.Value = "1";
      
      DynamicControlHolder.Controls.Add(control);
    }
