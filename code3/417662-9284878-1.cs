    List<string> myList = new List<string>();
    List<string> myTempList = new List<string>();
    // Add the item to a temporary list
    foreach (string a in myList)
    {
        if (a == "secretstring")
            myTempList.Add("secretstring");
    }
    // To remove the string
    foreach (string a in myTempList)
    {
        myList.Remove(a);
    }
