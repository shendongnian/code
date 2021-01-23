    string Namecolumnvalue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
    LinkButton lnk2 = (LinkButton)e.Row.FindControl("LinkButton2");
    if(Namecolumnvalue =="Disable")
    {      
      lnk2.Enabled=false;
    }
    else{
      lnk2.Enabled=true;
    }
    
