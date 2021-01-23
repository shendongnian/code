    public void Card_Inserted()
    {
      try
      {
        if (NFC.Connect())
        {
            //Do stuff like NFC.GetCardUID(); ...
        }
        else
        {
            //Give error message about connection...
        }
      }
      catch (Exception ex)
      {
        //Something went wrong
      }
    }
    
    public void Card_Ejected()
    {
       //Do stuff...
       NFC.Disconnect();
    }
