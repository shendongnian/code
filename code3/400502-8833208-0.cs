    private int listBoxItemCounter = 0;
    private void Interval(object sender, EventArgs e)
    {
       //setting interval
       
       if(listBoxItemCounter<lbMessage.Items.Count) 
       {
           SendKeys.Send(lbMessage.Items[listBoxItemCounter].ToString()+"{enter}");
           listBoxItemCounter++; 
       }
    }
