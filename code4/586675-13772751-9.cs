    private void button1_Click(object sender, EventArgs e)
    {
     foo(@"C:\temp","countries.txt");       
    }
    private void foo(string path,string choosenFile)
    {
        var custIndex = new List<int>();
        //if (choosenFile.Contains("Cust"))
        //{
            var lines = File.ReadAllLines(path + "\\" + choosenFile);
            List<CountryData> countryDataList = new List<CountryData>();
            List<StateData> stateDataList = new List<StateData>();
           
            foreach (string line in lines)
            {
                int errorCounter = 0;
                string[] items = line.Split('\t').ToArray();
                //Put all your logic back here...
                if (errorCounter == 0)
                {
                    var countryData = new CountryData()
                                          {
                                              FirstCountry = items[0],
                                              ThirdCountry = items[2]
                                          };
                    countryDataList.Add(countryData);
                    stateDataList.Add( new StateData() { SeceondCountryOption = items[1].Split(',')});
                }
            //}
          }
        
         dataGridView2.AutoGenerateColumns = false;
         dataGridView2.DataSource = countryDataList;
         seceondCountryOptionBindingSource.DataSource = stateDataList;
       
    }
