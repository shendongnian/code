    protected void LinkButtonClick(object sender, EventArgs e)
    {
    if(test())
       Response.Redirect("~/Test.aspx");
    else
       test();
    }
    public  Boolean test()
    {
      if(...)
         return false;
      else
         return true;
    }
