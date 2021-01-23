    namespace BusLogic
    {
    public class ProcessFiles
    {
    internal List<CountryData> CountryDataList = new List<CountryData>();
    internal List<MultiCountryData> MultiCountryDataList = new List<MultiCountryData>();
           
    internal void foo(string path,string choosenFile)
    {
        var custIndex = new List<int>();
        //if (choosenFile.Contains("Cust"))
        //{
            var lines = File.ReadAllLines(path + "\\" + choosenFile);
            foreach (string line in lines)
            {
                int errorCounter = 0;
                string[] items = line.Split('\t');
                //Put all your logic back here...
                if (errorCounter == 0)
                {
                    var countryData = new CountryData()
                                          {
                                              FirstCountry = items[0],
                                              ThirdCountry = items[2]
                                          };
                    countryDataList.Add(countryData);
                    multiCountryDataList.Add( new MultiCountryData() { SeceondCountryOption = items[1].Split(',')});
                }
            //}
          }
       
    }
    }
