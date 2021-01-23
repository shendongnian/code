    var A = new List<string> { "Beef", "Ham", "Chicken" };
    var B = new List<string> { "Cat", "Monkey", "Dog" };
    var C = new List<string> { "Veal", "Ham", "Beef", "Chicken", "Deer", "Dog", "Cat", "Monkey" };
    
    // To quickly check if C[i] belongs to the corresponding list.
    var sA = new HashSet<string>(A);
    var sB = new HashSet<string>(B);
    List<string> currentList = null;
    int pos = 1;
    for (int i = 0; i < C.Count; i++)
    {
    	string el = C[i];
    	if (currentList != null)
    	{
    		if (pos == currentList.Count)
    		{
    			pos = 1;
    			currentList = null;
    		}
    		else
    		{
    			C[i] = currentList[pos];
    			pos++;
    		}
    	}
    	else if (sA.Contains(el))
    	{
    		currentList = A;
    		C[i] = currentList[0];
    	}
    	else if (sB.Contains(el))
    	{
    		currentList = B;
    		C[i] = currentList[0];
    	}
    }
    
    // Outputs "Veal,Beef,Ham,Chicken,Deer,Cat,Monkey,Dog"
    Console.WriteLine(string.Join(",", C));
    
