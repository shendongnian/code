    protected void Button1_Click(object sender, EventArgs e)
    {
      ViewState["countmsg"] = Convert.ToInt32(ViewState["countmsg"]) +1;
      Application["abc"] = Application["abc"] + "hello" + Environment.NewLine;
      string str = Application["abc"].ToString();
         
       if (Convert.ToInt32(ViewState["countmsg"]) >= 4)
       {
        Application.Lock();
        Application["abc"] = "";    // now its working
        Application.UnLock();  
        ViewState["countmsg"] = 0;
      }
    }
