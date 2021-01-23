    var dataHelper = new DataHelper();
    List<dynamic> myFirstList = dataHelper.GetWhatIWant("PrimaryTable");
            
    for (int i = 0; i < 5 && i < myFirstList.Count; i++)
    {
        System.Console.WriteLine(String.Format("{0} - {1}", myFirstList[i].FirstValue.ToString(),  myFirstList[i].SecondValue.ToString()));
    }
    List<dynamic> mySecondList = dataHelper.GetWhatIWant("SecondaryTable");
    for (int i = 0; i < 5 && i < mySecondList.Count; i++)
    {
        System.Console.WriteLine(mySecondList[i].FirstSecondaryValue.ToString());
    }
    System.Console.ReadKey();
