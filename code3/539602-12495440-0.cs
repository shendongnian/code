    ArrayList maGroupNames; // This is my array of options (string)
    int mCategory; // This is my maskfield's result
   	for (int i = 0; i < maGroupNames.Count; i++)
   	{
   		int layer = 1 << i;
   		if ((mCategory & layer) != 0)
   		{
   			//This group is selected
   		}
   	}
