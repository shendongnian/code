    string[] rawDatas = GetData();
    foreach(string rawData in rawDatas)
    {
        short iRawData;
        if (Int16.TryParse(rawData, out iRawData))
        {
            if (iRawData == 1 || iRawData == 0)
            {
              //Add a bit
              iRawData;
            }
            else
            {
              // add a string
              rawData;
            }
        }
        else
        {
           //add a string
           rawData;
        }
    }
