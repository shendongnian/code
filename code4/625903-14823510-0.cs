      HtmlGenericControl control = FindControl("divMyusercontrols")
      var myControl = new MyControl();
      for(int i=0; i<numberOfUserControls; i++)
      {
         myControl.ID = "myUniqueID" + i; 
      }
      myControl.Controls.Add(myControl);
