    private void countButtonClick()
    {    
        int counter = 0;
        if (!(Session["counter"])){
           counter = (int)Session["counter"];
        }
        counter++;
        Session["counter"] = counter;
   
        if (counter >= 1)
        {
            Response.Write("You can only select 2 slots! " + DateTime.Now.ToString());
        }
    }
