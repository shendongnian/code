    int TotalCost;
    for (int index = 0; index < lstCakes.SelectedItems.Count; index++)
    {
      strCakes += Environment.NewLine + lstCakes.SelectedItems[index].ToString();
      
      //The name of the List Items should match the names on the enum,for this to work
      TotalCost += (int)Enum.Parse(typeof(CakePrices),
                                   lstCakes.SelectedItems[index].ToString() ,
                                   false)
    }
    Console.WriteLine("You have ordered:" + strCakes + '\n' + "Total Cost: " + TotalCost);
