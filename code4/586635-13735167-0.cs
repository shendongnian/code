                    public void checkSuites()
        {
            Dictionary<int, Control> btnList = new Dictionary<int, Control>();
            btnList.Add(1, suite1);
            btnList.Add(2, suite2);
            btnList.Add(3, suite3);
            btnList.Add(4, suite4);
            btnList.Add(5, suite5);
            SqlCeCommand checkSuite = new SqlCeCommand("SELECT * FROM RentSessionLog WHERE State='0'", mainConnection);
            SqlCeDataReader readSuite = checkSuite.ExecuteReader();
            while (readSuite.Read())
            {
                int suiteIndex = Convert.ToInt32(readSuite["SuiteNum"]);
                string suitePath = "suite" + suiteIndex;
                foreach (Button key in btnList.Values)
                {
                    if (key.Name == suitePath)
                    {
                     key.Image = NewSoftware.Properties.Resources.busySuiteImg;
                    }
                }
                }
            
        }
