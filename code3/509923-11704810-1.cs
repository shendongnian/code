    foreach(Control control in Page.Controls){
      if(control is System.Web.UI.WebControls.BaseValidator)
      {
         control.Display = "Static";
      }
    }
