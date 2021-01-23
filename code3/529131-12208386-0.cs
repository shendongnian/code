     public static void addItem(Potion item)
     {
    	if(Potions.ContainsKey(item.itemName))
    		Potions[item.itemName] += 1;
    	else
    		Potions.Add (item.itemName,1);
    	
    	foreach(KeyValuePair<string,int> pair in Potions)
    	{
    		Console.WriteLine(pair.Key + " : " + pair.Value);
    	}
     }
