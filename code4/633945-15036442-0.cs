    private void GenerateList(string[] wordlist)
    {
       List<string> wordList = wordlist.ToList(); // initialize the list passing in the array
        var uniqueStr = from item in wordList.Distinct().ToList()
                        orderby item
                        select item;
        txtOutput.Text = String.Join("\n", uniqueStr.ToArray());
    }
