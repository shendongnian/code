    List<string> myList1 = new List<string>();
    List<string> myList2 = new List<string>();
    int x = 0;
    foreach (string line in txtInput.Lines)
    {
        string[] splitInput = Regex.Split(line, ("\\s+"));
        myList1.Add(splitInput[0]);
        myList2.Add(splitInput[1]);
        txtOutPut.Text += "modified " + myList1[x] + "  " + myList2[x] + Environment.NewLine;
        x++;
    }
