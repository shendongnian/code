    {
      int controlCount = Convert.ToInt32(DynamicControlCount.Value);
      controlCount++;
      
      //This section will add as many controls as i.
      for(i = 1; i <= controlCount; i++)
      {
    	  MyUserControl control = Page.LoadControl("~/path_to_my_usercontrol");
    	  control.ID = String.Format("MyUserControl{0}", i);		  
    	  DynamicControlHolder.Controls.Add(control);			
      }
      
      DynamicControlCount.Value = Convert.ToString(controlCount); //Note this is problematic
    }
