    string message = "This Is A Test";
    string[] result = new string[message.Length];
    char[] temp = new char[message.Length];
    
    temp = message.ToCharArray();
    
    for (int i = 0; i < message.Length - 1; i++)
    {
         result[i] = Convert.ToString(temp[i]);
    }
