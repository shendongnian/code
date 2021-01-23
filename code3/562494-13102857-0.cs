    int TotalCost;
    for (int index = 0; index < lstCakes.SelectedItems.Count; index++)
    {
      strCakes += Environment.NewLine + lstCakes.SelectedItems[index].ToString();
      
      //The name of the List Items shouls match the names in the enum
      TotalCost += (int)Enum.Parse(typeof(CakePrices),
                                   lstCakes.SelectedItems[index].ToString() ,
                                   false)
    }
    Console.WriteLine("You have ordered:" + strCakes + '\n' + "Total Cost: " + TotalCost);
