    private int counter = 0;
    private void countButtonClick()
    {    
        counter++;
        if (counter >= 1)
        {
            Response.Write("You can only select 2 slots! " + DateTime.Now.ToString());
        }
    }
