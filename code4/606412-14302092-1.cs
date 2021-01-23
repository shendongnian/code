    private List<UInt32> ConvertTextToList(string TextBoxText)
    {
       ....
        var TextBoxSplittedAsList = TextBoxSplitted.ToList<string>(); //Fast
    
        TextBoxSplittedAsList.Select(int.Parse).ToList();
        TextBoxSplittedAsList.Distinct().ToList(); // to get the distinct values
