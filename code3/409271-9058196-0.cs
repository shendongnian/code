    Byte[] bArray = userList
    	.SelectMany(s => System.Text.Encoding.ASCII.GetBytes(s + '\0')) // Add 0 byte
    	.ToArray();
    
    List<string> names = new List<string>();
    for (int i = 0; i < bArray.Length; i++)
    {
    	int end = i;
    	while (bArray[end] != 0) // Scan for zero byte
    		end++;
    	var length = end - i;
    	var word = new byte[length];
    	Array.Copy(bArray, i, word, 0, length);
    	names.Add(ASCIIEncoding.ASCII.GetString(word));
    	i += length;
    }
