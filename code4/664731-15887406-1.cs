    string k = Console.ReadLine();
    
    string t = "";
    int count = 0, next;
    
    for (int i = 0; i < k.Length; i++)
    {
    	while (int.TryParse(k[i].ToString(), out next)) // Find the count of the next letter
    	{
    		count = count * 10 + next; // If count had a 2, and the next character is 3 (means we need to calculate 23), simply multiply the previous count by 10, and add the new digit
    		i++; // Move to the next character
    	}
    
    	t += new String(k[i], count > 0 ? count : 1); // Add the new sequence of letters to our string
    	count = 0; // Clear the current count
    }
    
    Console.WriteLine(t);
