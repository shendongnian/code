    foreach (Item ThisItem in TheseItems)
    {
        //Display properties of Item instance “ThisItem” (Excluded for ease of reading)
    
        if (ThisItem is Computer)
        {
           var ThisComputer = (Computer) ThisItem;
           Display(ThisComputer.CPU);
           //etc
        }
    }
