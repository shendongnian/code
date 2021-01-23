    private int counter = 0;
    protected void Page_Load()
    {
       if(!Page.IsPostback)
       {
          ViewState["MyClickCounter"] = 0;
       }
       else
       {
          counter = (int)ViewState["MyClickCounter"];
       }
    }
    private void countButtonClick()
    {
       counter++;
       ViewState["MyClickCounter"] = counter;
       if (counter >= 1)
       {
          Response.Write("You can only select 2 slots! " + DateTime.Now.ToString());
       }
    }
