    MyControl ctl =  this.MyControlPlaceHolder.FindControl("mycontrol");
    
    if (ctl != null){
                ctl.MyProperty = true;
                Response.Write("success");
            }
            else
                Response.Write("fail");
