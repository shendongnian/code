    int[] username = { 807301, 992032, 123144, 123432 };
    string[] password = { "Miami", "LosAngeles", "NewYork", "Dallas" };
    int enteredUserName = 123144;
    string enteredPassword = "NewYork";
    //find the index from the username array
    var indexResult = username.Select((r, i) => new { Value = r, Index = i })
                              .FirstOrDefault(r => r.Value == enteredUserName);
    if (indexResult == null)
    {
        Console.WriteLine("Invalid user name");
        return;
    }
    int indexOfUserName = indexResult.Index;
    //Compare the password from that index. 
    if (indexOfUserName < password.Length && password[indexOfUserName] == enteredPassword)
    {
        Console.WriteLine("User authenticated");
    }
    else
    {
        Console.WriteLine("Invalid password");
    }
