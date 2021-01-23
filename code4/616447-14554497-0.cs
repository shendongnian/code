    List<string> containter = new List<string>();
    for (int i = 0; i < 10; i++)
    {
        containter.Add("string #" + i);
    }
    //define a checklist
    List<string> checkList = new List<string> { "string #2", "string #6" };
    //we're in, if every item in checkList is present in container
    if (!checkList.Except(containter).Any())
    {
        Console.WriteLine("true");
    }
