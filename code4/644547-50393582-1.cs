    protected void mltv_Load(object sender, EventArgs e)
    {
       //Add your property backing or class variable here
       int pos = mltv.ActiveViewIndex;
       if (pos == -1)
           return;
       Context.Items["mltv_ActiveViewIndexOnLoad"] = pos;
    }
    protected void mltv_ActiveViewChanged(object sender, EventArgs e)
    {
       //Retrieve property, private variable, here:
       var lastViewIndex = -1; 
       if (Context.Items["mltv_ActiveViewIndexOnLoad"] != null)
       {
           lastViewIndex = (int)(Context.Items["mltv_ActiveViewIndexOnLoad"]);
       }
       
    }
